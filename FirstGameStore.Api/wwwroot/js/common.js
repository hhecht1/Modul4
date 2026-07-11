const API = '/games';

const GENRES = [
  'Action-Adventure',
  'Action-RPG',
  'RPG',
  'FPS',
  'MOBA',
  'Simulation',
  'Sandbox',
  'Battle Royale',
  'Party',
  'Sport'
];

function showMessage(text, type) {
  const msg = document.getElementById('message');
  if (!msg) return;

  msg.textContent = text;
  msg.className = type;
}

function formatDate(dateString) {
  return new Date(dateString).toLocaleDateString('de-CH');
}

function formatPrice(price) {
  return `${price.toFixed(2)} €`;
}

function populateGenreSelect(selectId, selectedValue = '') {
  const select = document.getElementById(selectId);
  if (!select) return;

  select.innerHTML = `
    <option value="">Bitte auswählen</option>
    ${GENRES.map(genre => `
      <option value="${genre}" ${genre === selectedValue ? 'selected' : ''}>
        ${genre}
      </option>
    `).join('')}
  `;
}