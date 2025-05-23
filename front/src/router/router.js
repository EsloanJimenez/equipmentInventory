import { createRouter, createWebHistory } from 'vue-router'

export const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('../views/MaintenanceTask.vue'),
    },
    {
      path: '/equipment',
      name: 'equipment',
      component: () => import('../views/Equipment.vue')
    },
  ]
})