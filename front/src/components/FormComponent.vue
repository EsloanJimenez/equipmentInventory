<template>
  <div class="mt-5">
    <div
      class="modal fade"
      id="contactModal"
      tabindex="-1"
      aria-labelledby="contactModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="contactModalLabel">
              {{ props.title }}
            </h5>
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Cerrar"
            ></button>
          </div>

          <div class="modal-body">
            <form @submit.prevent="handleAction">
              <div
                v-for="(field, index) in formFields"
                :key="index"
                class="mb-3"
              >
                <label :for="field.name" class="form-label">
                  {{ field.label }}
                </label>

                <input
                  v-if="
                    field.type !== 'select' && field.type !== 'checkbox-list'
                  "
                  :type="field.type"
                  v-model="field.value"
                  :name="field.name"
                  :id="field.name"
                  :maxlength="field.maxlength"
                  @input="(e) => limitInput(e, field)"
                  class="form-control"
                  :required="field.required"
                />

                <select
                  v-else-if="field.type === 'select'"
                  v-model="field.value"
                  :name="field.name"
                  :id="field.name"
                  class="form-control"
                  :required="field.required"
                >
                  <option
                    v-for="option in field.options"
                    :key="option.value"
                    :value="option.value"
                  >
                    {{ option.label }}
                  </option>
                </select>
                <div v-else-if="field.type === 'checkbox-list'">
                  <div
                    v-for="(option, idx) in field.options"
                    :key="idx"
                    class="form-check"
                  >
                    <input
                      class="form-check-input"
                      type="checkbox"
                      :id="`${field.brand}-${option.value}`"
                      :value="option.value"
                      v-model="field.value"
                      :checked="option.checked"
                    />
                    <label
                      class="form-check-label"
                      :for="`${field.brand}-${option.value}`"
                    >
                      {{ option.label }}
                    </label>
                  </div>
                </div>
              </div>
            </form>
          </div>

          <div class="modal-footer">
            <NewBotton
              :title="title"
              btnStyle="btn btn-primary"
              data-bs-dismiss="modal"
              @click="handleAction"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { defineProps, defineEmits, ref, watch, onMounted } from "vue";
import NewBotton from "./NewBotton.vue";
import { getEquipment } from "../services/equipment/get";

const datosEquipments = ref([]);

onMounted(async () => {
  datosEquipments.value = getEquipment();
});

const props = defineProps({
  title: String,
  fields: {
    type: Array,
    required: true,
  },
});

const formFields = ref([...props.fields]);
const isInput = ref();

const limitInput = (e, field) => {
  const inputValue = e.target.value;

  if (inputValue.length > field.maxlength) {
    field.value = inputValue.slice(0, field.maxlength);
  }
};

const emit = defineEmits(["send-data"]);

watch(
  () => props.fields,
  (newFields) => {
    formFields.value = newFields.map((field) => {
      if (field.type === "checkbox-list" && !Array.isArray(field.value)) {
        field.value = [];
      }
      return field;
    });
    isInput.value = formFields.value[0].name;
  }
);

const handleAction = () => {
  const formData = {};

  formFields.value.forEach((field) => {
    formData[field.name] = field.value;
  });

  emit("send-data", formData);
};
</script>
