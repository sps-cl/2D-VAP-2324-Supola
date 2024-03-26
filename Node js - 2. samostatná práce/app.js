const mysql2 = require('mysql2');
const express = require('express');
const path = require('path');

const conection = mysql2.createConnection(
    {
        host: '127.0.0.1',
        user: 'root',
        password: '',
        port: '3306',
        database: 'moje_databáze'
    }
);

conection.connect((error) => {
    if(error){
        console.log(error)
    } else {
        console.log("Vaše odpověď byla odeslaná.");
        const jmeno = "Šimon"
        const prijmeni = "Šupola"
        conection.query(
            `INSERT INTO uzivatel (jmeno, prijmeni) VALUES ('${jmeno}', '${prijmeni}')`,
            (error, data) => {
            if (error) console.log(error)
        });
        conection.query(
            'SELECT * FROM uzivatel;', (error, data) => {
                if (error) console.log(error);
                else {
                    console.log(data);
                }
            }
        )
    }
})

const app = express();
app.use(express.static(__dirname));
app.use(express.urlencoded({extended: true}));
app.use(express.json());

app.get("/", (req, res) => {
    res.sendFile(path.join(__dirname, 'index.html'));
})

app.post("/insert", (req, res) => {
    console.log(req.body);
    res.redirect("/");
})

app.listen(5500);