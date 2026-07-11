let allGames = [];

async function loadGames() {
  const grid = document.getElementById('gamesGrid');

  try {
    const res = await fetch(API);
    if (!res.ok) throw new Error('Fehler beim Laden der Spiele.');

    allGames = await res.json();
    fillGenreFilter(allGames);
    renderGames();
  } catch (error) {
    grid.innerHTML = `
      <div class="empty-state">
        <span class="empty-state-title">⚠ Fehler beim Laden</span>
        <div class="empty-state-text">Die Spiele konnten nicht geladen werden.</div>
      </div>
    `;
    showMessage(error.message, 'error');
  }
}

function fillGenreFilter(games) {
  const genreFilter = document.getElementById('genreFilter');
  const currentValue = genreFilter.value;
  const genres = [...new Set(games.map(g => g.genre))].sort();

  genreFilter.innerHTML = `
    <option value="">Alle Genres</option>
    ${genres.map(genre => `<option value="${genre}">${genre}</option>`).join('')}
  `;

  genreFilter.value = currentValue;
}

function getGenreBadgeClass(genre) {
  const normalized = genre.toLowerCase().replaceAll(' ', '-');

  switch (normalized) {
    case 'action-adventure':
      return 'badge-action-adventure';
    case 'action-rpg':
      return 'badge-action-rpg';
    case 'rpg':
      return 'badge-rpg';
    case 'fps':
      return 'badge-fps';
    case 'moba':
      return 'badge-moba';
    case 'simulation':
      return 'badge-simulation';
    case 'sandbox':
      return 'badge-sandbox';
    case 'battle-royale':
      return 'badge-battle-royale';
    case 'party':
      return 'badge-party';
    case 'sport':
      return 'badge-sport';
    default:
      return 'badge-default';
  }
}

function renderGames() {
  const grid = document.getElementById('gamesGrid');
  const searchText = document.getElementById('searchInput').value.toLowerCase().trim();
  const selectedGenre = document.getElementById('genreFilter').value;
  const sortValue = document.getElementById('sortFilter').value;

  let filteredGames = allGames.filter(game => {
    const matchesSearch = game.name.toLowerCase().includes(searchText);
    const matchesGenre = !selectedGenre || game.genre === selectedGenre;
    return matchesSearch && matchesGenre;
  });

  filteredGames.sort((a, b) => {
    switch (sortValue) {
      case 'price-asc':
        return a.price - b.price;
      case 'price-desc':
        return b.price - a.price;
      case 'date-desc':
        return new Date(b.releaseDate) - new Date(a.releaseDate);
      case 'date-asc':
        return new Date(a.releaseDate) - new Date(b.releaseDate);
      case 'name-asc':
      default:
        return a.name.localeCompare(b.name);
    }
  });

  if (filteredGames.length === 0) {
    grid.innerHTML = `
      <div class="empty-state">
        <span class="empty-state-title">🎮 Keine Spiele gefunden</span>
        <div class="empty-state-text">Passe deine Suche oder den Genre-Filter an.</div>
      </div>
    `;
    return;
  }

  grid.innerHTML = filteredGames.map(game => `
    <div class="game-card">
      <h2 class="game-title">${game.name}</h2>

      <div class="game-meta">
        <span class="badge ${getGenreBadgeClass(game.genre)}">🏷 ${game.genre}</span>
        <span class="badge badge-price">💰 ${formatPrice(game.price)}</span>
      </div>

      <div class="game-date">
        📅 Erscheinungsdatum: ${formatDate(game.releaseDate)}
      </div>

      <div class="card-actions">
        <a class="btn btn-edit" href="edit.html?id=${game.id}">✏ Bearbeiten</a>
        <button class="btn btn-delete" data-id="${game.id}">🗑 Löschen</button>
      </div>
    </div>
  `).join('');

  bindDeleteButtons();
}

function bindDeleteButtons() {
  const buttons = document.querySelectorAll('.btn-delete');

  buttons.forEach(button => {
    button.addEventListener('click', async () => {
      const id = button.dataset.id;

      if (!confirm('Spiel wirklich löschen?')) return;

      try {
        const res = await fetch(`${API}/${id}`, { method: 'DELETE' });

        if (res.ok) {
          showMessage('Spiel erfolgreich gelöscht.', 'success');
          await loadGames();
        } else {
          showMessage('Fehler beim Löschen.', 'error');
        }
      } catch {
        showMessage('Server nicht erreichbar.', 'error');
      }
    });
  });
}

document.getElementById('searchInput').addEventListener('input', renderGames);
document.getElementById('genreFilter').addEventListener('change', renderGames);
document.getElementById('sortFilter').addEventListener('change', renderGames);

loadGames();