
<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="app-shell">
    <header class="site-header">
      <div class="header-inner">
        <RouterLink to="/" class="brand">
          ✚ HospitalSystem
        </RouterLink>

        <nav class="site-nav">
          <RouterLink to="/">Home</RouterLink>
          <a href="/#services">Services</a>
        </nav>
      </div>
    </header>

    <RouterView />

    <footer class="site-footer">
      © 2026 HospitalSystem. Student Project.
    </footer>
  </div>
</template>
