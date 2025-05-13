<template>
  <button type="button" :class="[props.btnStyle]" @click="handleClick">
    {{ props.title }}
  </button>
</template>

<script setup>
import { defineProps, defineEmits } from "vue";

const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  btnStyle: {
    type: String,
    default: "btn btn-primary",
  },
});

const emit = defineEmits(["update-title"]);

const handleClick = () => {
  emit("update-title", props.title);
};
</script>
