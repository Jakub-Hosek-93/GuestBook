
apiURL = "/";

// funkce na Načtení
async function LoadGuestBookAPI() {
    try {
        const response = await fetch(apiUrl);
        const data = await response.json();
        
        const tableBody = document.getElementById('guestbook-entries');
        tableBody.innerHTML = '';

        data.forEach(item => {
            const row = document.createElement('tr');
            const date = new Date(item.date).toLocaleString('cs-CZ');
            
            row.innerHTML = `
                        <td class="name-col">${item.name}</td>
                        <td class="text-col">${item.text}</td>
                        <td class="date-col">${date}</td>
                    `;
            tableBody.appendChild(row);
        })
    }
    catch (err){
        console.error("Chyba:", err)
    }
    
    
}

// funkce na Přidáni
async function NewEntry(){
}