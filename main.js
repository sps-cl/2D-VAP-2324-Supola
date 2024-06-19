const express = require('express');
const mysql = require('mysql2');
const app = express();
const port = 5500; // Nastavení portu

const con = mysql.createConnection({ // Připojení k MySQL databázi
    host: "10.0.1.9",
    port: "3306",
    user: "root",
    password: "root",
    database: "nodejs_02"
});

con.connect((err) => { // Ověření připojení
    if (err) {
        console.error('Error connecting to MySQL:', err.stack); // Chyba připojení
        return;
    }
    console.log('Connected to MySQL database'); // Úspěšné připojení
});

app.use(express.urlencoded({ extended: true }));

app.post('/add-user', (req, res) => {
    const { name, surname } = req.body; // Získání jména a příjmení
    const sql = `INSERT INTO users (name, surname) VALUES (?, ?)`; // SQL dotaz pro vložení uživatele
    con.query(sql, [name, surname], (err, result) => { // Vykonání SQL dotazu
        if (err) {
            console.error('Error inserting data:', err.stack); // Chyba
            res.status(500).send('Error inserting data into database'); // Odpověď
            return;
        }
        console.log('Data inserted successfully'); // Úspěšné vložení dat
        res.redirect('/get-users'); // Přesměrování
    });
});

app.get('/get-users', (req, res) => { // Endpoint pro získání všech uživatelů z databáze
    con.query("SELECT * FROM users", (err, result) => { // SQL dotaz pro získání všech uživatelů
        if (err) {
            console.error('Error retrieving data:', err.stack); // Chyba
            res.status(500).send('Error retrieving data from database'); // Odpověď
            return;
        }
        res.json(result); // Odeslání výsledku
    });
});

app.listen(port, () => { // Spuštění serveru
    console.log(`Server running on http://localhost:${port}`); // Zpráva o spuštění
});
