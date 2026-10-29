
<script setup>
import { ref } from 'vue'

const selectedService = ref(null)

const selectedDoctor = ref('')
const appointmentDate = ref('')
const appointmentTime = ref('')

const doctors = [
  { id: 1, name: 'Dr. Emily Carter' },
  { id: 2, name: 'Dr. James Wilson' },
  { id: 3, name: 'Dr. Sophia Brown' },
]

const availableTimes = [
  '09:00',
  '10:00',
  '11:00',
  '13:00',
  '14:00',
  '15:00',
]


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
      <h2>Appointment Details</h2>

      <p>
        Selected service:
        <strong>{{ selectedService.name }}</strong>
      </p>

      <div class="booking-fields">
        <label>
          Choose a Doctor

          <select v-model="selectedDoctor">
            <option disabled value="">
              Select a doctor
            </option>

            <option
              v-for="doctor in doctors"
              :key="doctor.id"
              :value="doctor.name"
            >
              {{ doctor.name }}
            </option>
          </select>
        </label>

        <label>
          Appointment Date

          <input
            v-model="appointmentDate"
            type="date"
          />
        </label>

        <label>
          Available Time

          <select v-model="appointmentTime">
            <option disabled value="">
              Select a time
            </option>

            <option
              v-for="time in availableTimes"
              :key="time"
              :value="time"
            >
              {{ time }}
            </option>
          </select>
        </label>
      </div>

      <div
        v-if="selectedDoctor && appointmentDate && appointmentTime"
        class="booking-preview"
      >
        <h3>Appointment Preview</h3>

        <p>Service: {{ selectedService.name }}</p>
        <p>Doctor: {{ selectedDoctor }}</p>
        <p>Date: {{ appointmentDate }}</p>
        <p>Time: {{ appointmentTime }}</p>

        <small>
          Demo only. Your appointment has not been booked.
        </small>
      </div>
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


.booking-fields {
  display: grid;
  grid-template-columns: repeat(
    auto-fit,
    minmax(220px, 1fr)
  );
  gap: 20px;
  margin-top: 25px;
}

.booking-fields label {
  display: flex;
  flex-direction: column;
  gap: 10px;
  font-weight: 600;
  color: #163b65;
}

.booking-fields select,
.booking-fields input {
  width: 100%;
  padding: 12px;
  border: 1px solid #dbe5ef;
  border-radius: 8px;
  background-color: white;
  color: #233b53;
  font: inherit;
}

.booking-preview {
  margin-top: 30px;
  padding: 20px;
  background-color: white;
  border: 1px solid #c5dceb;
  border-radius: 10px;
}

.booking-preview h3 {
  color: #163b65;
}

.booking-preview small {
  color: #6e7c8d;
}


</style>
