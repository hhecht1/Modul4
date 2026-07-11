populateGenreSelect('genre');

document.getElementById('createForm').addEventListener('submit', async (e) => {
  e.preventDefault();

  const body = {
    name: document.getElementById('name').value.trim(),
    genre: document.getElementById('genre').value,
    price: parseFloat(document.getElementById('price').value),
    releaseDate: document.getElementById('releaseDate').value
  };

  try {
    const res = await fetch(API, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(body)
    });

    if (res.ok) {
      showMessage('Spiel erfolgreich erstellt! Weiterleitung...', 'success');
      e.target.reset();
      populateGenreSelect('genre');

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