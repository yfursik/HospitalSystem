
<template>
  <main class="home">
    <section class="hero">
      <h1>Welcome to HospitalSystem</h1>
      <p>
        Your health, our priority.
        Book appointments, schedule vaccinations,
        and access your medical records.
      </p>
      <button class="primary-button">
        Book an Appointment
      </button>
    </section>

    <section id="services" class="services">
      <h2>Our Services</h2>

      <div class="cards">
        <div class="card">
          <h3>Medical Examinations</h3>
          <p>Schedule appointments with doctors.</p>
        </div>

        <div class="card">
          <h3>Vaccinations</h3>
          <p>Book your vaccination online.</p>
        </div>

        <div class="card">
          <h3>Health Records</h3>
          <p>View your examination results.</p>
        </div>
      </div>
    </section>
  </main>
</template>

<style scoped>
.home {
  font-family: Arial, sans-serif;
}

.hero {
  padding: 50px 25px;
  background-color: #eaf4ff;
  border-radius: 12px;
  text-align: center;
}

.hero h1 {
  color: #163b65;
  font-size: 32px;
}

.hero p {
  color: #526579;
  line-height: 1.6;
}

.primary-button {
  background-color: #2476bd;
  color: white;
  border: none;
  padding: 12px 24px;
  border-radius: 8px;
  cursor: pointer;
}

.services {
  margin-top: 40px;
}

.cards {
  display: grid;
  grid-template-columns: repeat(
    auto-fit,
    minmax(200px, 1fr)
  );
  gap: 20px;
}

.card {
  padding: 20px;
  border: 1px solid #dbe5ef;
  border-radius: 10px;
}

.card h3 {
  color: #163b65;
}
</style>
