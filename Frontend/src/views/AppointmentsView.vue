
<script setup>
import { ref } from 'vue'

const selectedService = ref(null)

const services = [
  {
    id: 1,
    name: 'General Examination',
    description: 'Routine health check with a doctor.',
    duration: '30 minutes',
  },
  {
    id: 2,
    name: 'Blood Test',
    description: 'Laboratory blood examination.',
    duration: '15 minutes',
  },
  {
    id: 3,
    name: 'Flu Vaccination',
    description: 'Seasonal influenza vaccination.',
    duration: '15 minutes',
  },
]
</script>

<template>
  <main class="appointments-page">
    <h1>Book an Appointment</h1>
    <p class="subtitle">
      Choose a medical service to get started.
    </p>

    <div class="service-list">
      <article
        v-for="service in services"
        :key="service.id"
        class="service-card"
      >
        <h2>{{ service.name }}</h2>
        <p>{{ service.description }}</p>
        <span>Duration: {{ service.duration }}</span>
        <button
          type="button"
          class="select-button"
          @click="selectedService = service"
        >
          Select Service
        </button>
      </article>
    </div>

    <div v-if="selectedService" class="selected-service">
      Selected service:
      <strong>{{ selectedService.name }}</strong>
    </div>

    <p class="notice">
      Online booking will be available soon.
    </p>
  </main>
</template>

<style scoped>
.appointments-page {
  max-width: 1100px;
  width: 100%;
  margin: 0 auto;
  padding: 50px 24px;
}

h1 {
  color: #163b65;
}

.subtitle {
  color: #526579;
  margin-bottom: 30px;
}

.service-list {
  display: grid;
  grid-template-columns: repeat(
    auto-fit,
    minmax(240px, 1fr)
  );
  gap: 20px;
}

.service-card {
  background: white;
  border: 1px solid #dbe5ef;
  border-radius: 12px;
  padding: 24px;
}

.service-card h2 {
  color: #163b65;
  font-size: 20px;
}

.service-card p {
  color: #526579;
}

.service-card span {
  color: #2476bd;
  font-size: 14px;
}

.notice {
  margin-top: 30px;
  color: #6e7c8d;
}


.select-button {
  display: block;
  margin-top: 20px;
  padding: 10px 18px;
  background-color: #2476bd;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
}

.select-button:hover {
  background-color: #185a94;
}

.selected-service {
  margin-top: 25px;
  padding: 20px;
  background-color: #eaf4ff;
  border-radius: 10px;
  color: #163b65;
}

</style>
