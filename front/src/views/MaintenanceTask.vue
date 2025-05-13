<template>
  <HeaderComponent />
  <div class="container mt-5">
    <div id="table-header">
      <h2 class="mb-4">Lista De Tareas</h2>
      <input
        type="text"
        v-model="search"
        class="form form-control"
        name="search"
        id="search"
        placeholder="Buscar Por Descripción"
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
          <th>Descripción</th>
          <th>Equipos seleccionados</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody v-if="filterDescription.length > 0">
        <tr v-for="(item, i) in filterDescription" :key="i">
          <td>{{ item.id }}</td>
          <td>{{ item.description }}</td>
          <td>
            {{ selectedEquipments(item.equipments) }}
          </td>
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
    :form-data="selectedMaintenanceTask"
    @send-data="onSubmit"
  />
</template>

<script setup>
import { computed, onMounted, ref } from "vue";
import HeaderComponent from "../components/HeaderComponent.vue";
import NewBotton from "../components/NewBotton.vue";
import FormComponent from "../components/FormComponent.vue";
import { postMaintenanceTask } from "../services/maintenanceTask/post";
import { getMaintenanceTask } from "../services/maintenanceTask/get";
import { putMaintenanceTask } from "../services/maintenanceTask/put";
import { deleteMaintenanceTask } from "../services/maintenanceTask/deleted";
import { getEquipment } from "../services/equipment/get";
import { show_alert } from "../utils/swal";
import Swal from "sweetalert2";

import "../css/table.css";

const search = ref("");
const receivedData = ref({});
const dataMaintenanceTask = ref([]);
const dataEquipment = ref([]);
const modalTitle = ref("");
const modalFields = ref([]);
const isEditMode = ref(false);
const selectedMaintenanceTask = ref({});

onMounted(async () => {
  dataMaintenanceTask.value = await getMaintenanceTask();
  dataEquipment.value = await getEquipment();
});

const filterDescription = computed(() =>
  dataMaintenanceTask.value.filter((n) =>
    n.description.toLowerCase().includes(search.value.toLowerCase())
  )
);

const selectedEquipments = (list) => {
  if (list?.length == 0) return "";

  return list
    .map((l) => `${l.brand} - ${l.model} - ${l.description}`)
    .join(", ");
};

const openModal = async (
  action = "Registrar Tarea",
  maintenanceTask = null
) => {
  isEditMode.value = action === "Actualizar";
  modalTitle.value = isEditMode.value ? "Actualizar" : "Registrar Tarea";

  selectedMaintenanceTask.value = maintenanceTask ? { ...maintenanceTask } : {};

  const equipments = maintenanceTask ? maintenanceTask.equipments : [];

  modalFields.value = [
    {
      label: "Descripcion",
      name: "description",
      type: "text",
      value: maintenanceTask ? maintenanceTask.description : "",
      maxlength: 200,
      required: true,
    },
    {
      label: "Equipos",
      name: "equipments",
      type: "checkbox-list",
      value: equipments.map((t) => t.id),
      options: dataEquipment.value.map((e) => ({
        label: `${e.brand} ${e.model} ${e.description}`,
        value: e.id,
        checked:
          maintenanceTask?.equipments?.map((m) => m.id).includes(e.id) ?? false,
      })),
    },
  ];
};

const remove = async (data) => {
  Swal.fire({
    title: `Seguro de eliminar la tarea: ${data.description}?`,
    text: "No se podra dar marcha a tras",
    icon: "question",
    showCancelButton: true,
    confirmButtonText: "Si, eliminar",
    cancelButtonText: "cancelar",
  }).then(async (result) => {
    if (result.isConfirmed) {
      await deleteMaintenanceTask(data.id, data.description);
      dataMaintenanceTask.value = await getMaintenanceTask();
    } else show_alert("La tarea no fue eliminada", "info");
  });
};

const onSubmit = async (data) => {
  receivedData.value = {
    ...data,
    equipments: dataEquipment.value.filter((s) =>
      data.equipments.includes(s.id)
    ),
  };

  if (!receivedData.value.description?.trim()) {
    show_alert("El campo descripción es obligatorio.", "warning");
    return;
  }
  if (receivedData.value.equipments.length <= 0) {
    show_alert("Debe seleccionar por lo menos un equipo.", "warning");
    return;
  }

  if (isEditMode.value) {
    await putMaintenanceTask(selectedMaintenanceTask.value.id, {
      id: selectedMaintenanceTask.value.id,
      ...receivedData.value,
    });
  } else {
    await postMaintenanceTask(receivedData.value);
  }

  dataMaintenanceTask.value = await getMaintenanceTask();
};
</script>

<style scoped></style>
