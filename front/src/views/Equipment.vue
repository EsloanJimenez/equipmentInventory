<template>
  <HeaderComponent />
  <div class="container mt-5">
    <div id="table-header">
      <h2 class="mb-4">Lista De Equipos</h2>
      <input
        type="text"
        v-model="search"
        class="form form-control"
        name="search"
        id="search"
        placeholder="Buscar Por Marca"
      />
      <NewBotton
        title="+"
        btnStyle="btn btn-primary btn-add"
        data-bs-toggle="modal"
        data-bs-target="#contactModal"
        @click="openModal"
      />
    </div>
    <table class="table table-striped table-hover table-bordered">
      <thead class="table-success">
        <tr>
          <td>#</td>
          <th>Marca</th>
          <th>Modelo</th>
          <th>Tipo</th>
          <th>Fecha De Compra</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody v-if="filterBrand.length > 0">
        <tr v-for="(item, i) in filterBrand" :key="i">
          <td>{{ item.id }}</td>
          <td>{{ item.brand }}</td>
          <td>{{ item.model }}</td>
          <td>{{ item.description }}</td>
          <td>{{ formatDate(item.purchaseDate) }}</td>
          <td class="btn-action">
            <NewBotton
              title="Actualizar"
              btnStyle="btn btn-warning btn-sm me-2"
              data-bs-toggle="modal"
              data-bs-target="#contactModal"
              @click="openModal('Actualizar', item)"
            />
            <NewBotton
              title="Eliminar"
              btnStyle="btn btn-danger btn-sm"
              @click="remove(item)"
            />
          </td>
        </tr>
      </tbody>
    </table>
  </div>

  <FormComponent
    :title="modalTitle"
    :fields="modalFields"
    :form-data="selectedEquipment"
    @send-data="onSubmit"
  />
</template>

<script setup>
import { computed, onMounted, ref } from "vue";
import HeaderComponent from "../components/HeaderComponent.vue";
import NewBotton from "../components/NewBotton.vue";
import FormComponent from "../components/FormComponent.vue";
import { postEquipment } from "../services/equipment/post";
import { getEquipment } from "../services/equipment/get";
import { getEquipmentType } from "../services/equipmentType/get";
import { putEquipment } from "../services/equipment/put";
import { deleteEquipment } from "../services/equipment/deleted";
import Swal from "sweetalert2";

import "../css/table.css";

const search = ref("");
const receivedData = ref({});
const dataEquipment = ref([]);
const dataEquipmentType = ref([]);
const modalTitle = ref("");
const modalFields = ref([]);
const isEditMode = ref(false);
const selectedEquipment = ref({});

onMounted(async () => {
  dataEquipment.value = await getEquipment();
  dataEquipmentType.value = await getEquipmentType();
});

const filterBrand = computed(() =>
  dataEquipment.value.filter((n) =>
    n.brand.toLowerCase().includes(search.value.toLowerCase())
  )
);

const openModal = (action = "Registrar Equipo", equipment = null) => {
  isEditMode.value = action === "Actualizar";
  modalTitle.value = isEditMode.value ? "Actualizar" : "Registrar Equipo";

  selectedEquipment.value = equipment ? { ...equipment } : {};

  modalFields.value = [
    {
      label: "Marca",
      name: "brand",
      type: "text",
      value: equipment ? equipment.brand : "",
      maxlength: 100,
      required: true,
    },
    {
      label: "Modelo",
      name: "model",
      type: "text",
      value: equipment ? equipment.model : "",
      maxlength: 100,
      required: true,
    },
    {
      label: "Tipo De Equipo",
      name: "equipmentTypeId",
      type: "select",
      value: equipment ? equipment.equipmentTypeId : "",
      options: datosEquipmentType.value.map((equi) => ({
        label: equi.description,
        value: equi.id,
      })),
      required: true,
    },
    {
      label: "Numero De Serial",
      name: "serialNumber",
      type: "text",
      value: equipment ? equipment.serialNumber : "",
      maxlength: 30,
    },
    {
      label: "Fecha Compra",
      name: "purchaseDate",
      type: "date",
      value: equipment ? formatDate(equipment.purchaseDate) : "",
      required: true,
    },
  ];
};
const formatDate = (date) => {
  if (!date) return "";
  const d = new Date(date);
  const year = d.getFullYear();
  const month = String(d.getMonth() + 1).padStart(2, "0");
  const day = String(d.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
};

const remove = async (data) => {
  Swal.fire({
    title: `Seguro de eliminar el equipo: ${data.brand} ${data.model}?`,
    text: "No se podrá dar marcha atrás",
    icon: "question",
    showCancelButton: true,
    confirmButtonText: "Si, eliminar",
    cancelButtonText: "cancelar",
  }).then(async (result) => {
    if (result.isConfirmed) {
      await deleteEquipment(data.id, data);

      dataEquipment.value = await getEquipment();
    } else show_alert("La tarea no fue eliminada", "info");
  });
};

const onSubmit = async (data) => {
  receivedData.value = data;

  if (!receivedData.value.brand?.trim()) {
    show_alert("El campo marca es obligatorio.", "warning");
    return;
  }
  if (!receivedData.value.model?.trim()) {
    show_alert("El campo modelo es obligatorio.", "warning");
    return;
  }
  if (!receivedData.value.equipmentTypeId) {
    show_alert("El campo tipo de equipo es obligatorio.", "warning");
    return;
  }
  if (!receivedData.value.purchaseDate) {
    show_alert("El campo fecha de compra es obligatorio.", "warning");
    return;
  }

  if (isEditMode.value) {
    await putEquipment(selectedEquipment.value.id, {
      id: selectedEquipment.value.id,
      ...receivedData.value,
    });
  } else {
    await postEquipment(receivedData.value);
  }

  dataEquipment.value = await getEquipment();
};
</script>

<style scoped></style>
