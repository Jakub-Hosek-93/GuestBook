apiURL = "/";

// funkce na Načtení
async function LoadGuestBookAPI() {
    try {
        const response = await fetch(apiURL);
        const data = await response.json();

        const tableBody = document.getElementById('guestbook-table');
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
    const nameInput = document.getElementById('name').value;
    const textInput = document.getElementById('message').value;

    if (!nameInput || !textInput) {
        alert("Vyplňte prosím jméno i vzkaz.");
        return;
    }

    const entry = {
        name: nameInput,
        text: textInput
    };

    try {
        await fetch(apiURL, {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(entry)
        });

        document.getElementById('name').value = '';
        document.getElementById('message').value = '';
        
        LoadGuestBookAPI();
    }catch(err){
        console.error("Chyba:", err)
    }
}

LoadGuestBookAPI();