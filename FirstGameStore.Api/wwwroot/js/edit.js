const params = new URLSearchParams(window.location.search);
const id = params.get('id');

populateGenreSelect('genre');

async function loadGame() {
  if (!id) {
    showError('Keine Spiel-ID angegeben.');
    return;
  }

  try {
    const res = await fetch(`${API}/${id}`);
    if (!res.ok) {
      showError('Spiel nicht gefunden.');
      return;
    }

    const game = await res.json();
    document.getElementById('name').value = game.name;
    populateGenreSelect('genre', game.genre);
    document.getElementById('price').value = game.price;
    document.getElementById('releaseDate').value = game.releaseDate;
  } catch {
    showError('Server nicht erreichbar.');
  }
}

document.getElementById('editForm').addEventListener('submit', async (e) => {
  e.preventDefault();

  const body = {
    name: document.getElementById('name').value.trim(),
    genre: document.getElementById('genre').value,
    price: parseFloat(document.getElementById('price').value),
    releaseDate: document.getElementById('releaseDate').value
  };

  try {
    const res = await fetch(`${API}/${id}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(body)
    });

    if (res.ok) {
      showMessage('Spiel erfolgreich aktualisiert! Weiterleitung...', 'success');

      setTimeout(() => {
        window.location.href = 'index.html';
      }, 1200);
    } else {
      const text = await res.text();
      showMessage('Fehler: ' + (text || res.statusText), 'error');
    }
  } catch {
    showMessage('Server nicht erreichbar.', 'error');
  }
});

function showError(text) {
  showMessage(text, 'error');
  document.getElementById('editForm').style.display = 'none';
}

loadGame();