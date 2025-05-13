<template>
  <svg
    @click="toggleStyle"
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 448 512"
  >
    <!Font Awesome Free 6.6.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.-->
    <path
      d="M0 96C0 78.3 14.3 64 32 64l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 128C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 288c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32L32 448c-17.7 0-32-14.3-32-32s14.3-32 32-32l384 0c17.7 0 32 14.3 32 32z"
    />
  </svg>
  <header :class="{ translate: isTranslate }">
    <nav>
      <ul>
        <li>
          <router-link to="/">Tareas</router-link>
        </li>
        <li>
          <router-link to="/equipment">Equipos</router-link>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script setup>
import { ref } from "vue";

const isTranslate = ref(true);

const toggleStyle = () => {
  isTranslate.value = !isTranslate.value;
};
</script>

<style scoped>
.grid-td {
  text-align: center;
}
header {
  width: 100%;
  position: fixed;
  top: 0;
  background-color: #333;
  user-select: none;
  z-index: 100;
}
svg {
  display: none;
}
nav ul {
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: space-around;
}
nav ul img {
  width: 110px;
}
nav ul li {
  margin: 0;
}
nav ul li a {
  color: white;
  text-decoration: none;
  padding: 15px 20px;
  display: block;
}
nav ul li a:hover {
  background-color: #555;
}

@media only screen and (max-width: 768px) {
  header {
    background-color: #333333e3;
    transition: all ease 0.5s;
  }
  .translate {
    transform: translateX(-100%);
  }
  .isTranslate {
    transform: translateX(0);
  }
  header nav {
    margin-top: 50px;
  }
  svg {
    width: 35px;
    position: fixed;
    top: 10px;
    left: 15px;
    display: block;
    cursor: pointer;
    z-index: 1000;
  }
  nav ul {
    flex-direction: column;
    align-items: flex-start;
  }
  nav ul li {
    width: 100%;
  }
  nav ul li a {
    width: 100%;
    padding: 10px 15px;
  }
}

@media only screen and (max-width: 480px) {
  nav ul li a {
    box-sizing: border-box;
  }
}
</style>
