"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
const readline = __importStar(require("readline-sync"));
const fs = __importStar(require("fs"));
class BaseBook {
    constructor(title, author, pages, publishedYear, isbn, quantity) {
        this.title = title;
        this.author = author;
        this.pages = pages;
        this.publishedYear = publishedYear;
        this.isbn = isbn;
        this.quantity = quantity;
    }
}
//Classe Libro
class Book extends BaseBook {
    constructor(title, author, pages, publishedYear, genre, publisher, isbn, quantity) {
        super(title, author, pages, publishedYear, isbn, quantity);
        this.genre = genre;
        this.publisher = publisher;
    }
    printBookInfo() {
        return `Titolo: ${this.title}, Genere: ${this.genre}, Autore: ${this.author}, Pagine: ${this.pages}, Pubblicazione: ${this.publishedYear}, Editore: ${this.publisher} Quantità: ${this.quantity}, ISBN: ${this.isbn}`;
    }
}
//Classe Manga
class Comics extends BaseBook {
    constructor(type, title, volume, author, pages, color, publishedYear, isbn, publisher, quantity) {
        super(title, author, pages, publishedYear, isbn, quantity);
        this.publisher = publisher;
        this.color = color;
        this.type = type;
        this.volume = volume;
    }
    printBookInfo() {
        return `Titolo: ${this.title}, Autore: ${this.author}, Volume: ${this.volume}, A Colori: ${this.color}, Editore: ${this.publisher}, Pubblicazione: ${this.publishedYear}, Pagine: ${this.pages}, Quantità: ${this.quantity}, ISBN: ${this.isbn}`;
    }
}
//Libreria
class Library {
    constructor() {
        this.library = [];
        this.currentYear = new Date().getFullYear();
    }
    add(libroDaAggiungere) {
        const libroTrovato = this.library.find(b => b.isbn === libroDaAggiungere.isbn);
        if (libroTrovato) {
            libroTrovato.quantity += 1;
        }
        else {
            this.library.push(libroDaAggiungere);
        }
    }
    printLibrary() {
        this.library.forEach(b => {
            console.log('--------------------------------------------');
            console.log(b.printBookInfo());
            console.log('--------------------------------------------');
        });
    }
    findBooksByAuthor() {
        let search = readline.question("Inserisci l'autore del libro: ");
        return this.library.filter((book) => (book.author.toLowerCase().includes(search.toLowerCase())));
    }
    findBooksByIsbn() {
        let search = Number(readline.question("Inserisci il codice ISBN del libro da cercare: "));
        while (isNaN(search) || search <= 0 || search.toString().length != 4 || !Number.isInteger(search)) {
            console.log("Dato non valido, riprova.");
            search = Number(readline.question("Inserisci il codice ISBN del libro da cercare: "));
        }
        return this.library.find((book) => (book.isbn === search));
    }
    findBooksByTitle() {
        let search = readline.question("Inserisci il titolo del libro: ");
        return this.library.filter((book) => (book.title.toLowerCase().includes(search.toLowerCase())));
    }
    findBooksByPublishedYear() {
        let search = Number(readline.question("Inserisci l'anno di pubblicazione del libro: "));
        while (isNaN(search) || search <= 0 || search.toString().length != 4 || !Number.isInteger(search)) {
            console.log("Dato non valido, riprova.");
            search = Number(readline.question("Inserisci l'anno di pubblicazione del libro: "));
        }
        return this.library.filter((book) => (book.publishedYear === search));
    }
    checkoutBook() {
        let cerca;
        do {
            cerca = Number(readline.question("Inserisci il codice ISBN del libro da prendere: "));
            if (isNaN(cerca) || cerca <= 0 || cerca.toString().length !== 4 || !Number.isInteger(cerca)) {
                console.log("ISBN non valido.");
            }
        } while (isNaN(cerca) || cerca <= 0 || cerca.toString().length !== 4 || !Number.isInteger(cerca));
        const book = this.library.find((book) => (book.isbn === cerca));
        const confirm = readline.keyInYNStrict("Sei sicuro di volerlo prendere in prestito?");
        if (!confirm) {
            console.log("Operazione annullata.");
        }
        else {
            if (book) {
                if (book.quantity > 0) {
                    book.quantity -= 1;
                    console.log(`Hai preso: ${book.title}. Rimangono ${book.quantity} copie disponibili.`);
                }
                else {
                    console.log("Il libro non e' disponibile.");
                }
            }
            else {
                console.log("Nessun libro trovato.");
            }
        }
    }
    returnBook() {
        let cerca;
        do {
            cerca = Number(readline.question("Inserisci il codice ISBN del libro da restituire: "));
            if (isNaN(cerca) || cerca <= 0 || cerca.toString().length !== 4 || !Number.isInteger(cerca)) {
                console.log("ISBN non valido.");
            }
        } while (isNaN(cerca) || cerca <= 0 || cerca.toString().length !== 4 || !Number.isInteger(cerca));
        const book = this.library.find((book) => (book.isbn === cerca));
        const confirm = readline.keyInYNStrict("Sei sicuro di restituirlo?");
        if (!confirm) {
            console.log("Operazione annullata.");
        }
        else {
            if (book) {
                book.quantity += 1;
                console.log(`Grazie per aver restituito: ${book.title}.`);
            }
            else {
                console.log("Nessun libro trovato.");
            }
        }
    }
    deleteABook() {
        let cerca;
        do {
            cerca = Number(readline.question("Inserisci il codice ISBN del libro da eliminare: "));
            if (isNaN(cerca) || cerca <= 0 || cerca.toString().length !== 4 || !Number.isInteger(cerca)) {
                console.log("ISBN non valido.");
            }
        } while (isNaN(cerca) || cerca <= 0 || cerca.toString().length !== 4 || !Number.isInteger(cerca));
        const book = this.library.findIndex((book) => (book.isbn === cerca));
        if (book !== -1) {
            const confirm = readline.keyInYNStrict("Sei sicuro di voler eliminare questo libro?");
            if (!confirm) {
                console.log("Operazione annullata.");
            }
            else {
                this.library.splice(book, 1);
                console.log(`Hai eliminato il libro con ISBN: ${cerca}.`);
            }
        }
        else {
            console.log("Nessun libro trovato.");
        }
    }
    saveToFile(filePath) {
        const data = JSON.stringify(this.library, null, 2);
        fs.writeFileSync(filePath, data, "utf-8");
        console.log("Libreria salvata con successo.");
    }
    loadFromFile(filePath) {
        if (fs.existsSync(filePath)) {
            const data = fs.readFileSync(filePath, "utf-8");
            const parsedData = JSON.parse(data);
            // Ricostruisci gli oggetti corretti (Book o Comics)
            this.library = parsedData.map((item) => {
                if (item.type) {
                    return new Comics(item.type, item.title, item.volume, item.author, item.pages, item.color, item.publishedYear, item.isbn, item.publisher, item.quantity);
                }
                else {
                    return new Book(item.title, item.author, item.pages, item.publishedYear, item.genre, item.publisher, item.isbn, item.quantity);
                }
            });
            console.log("Libreria caricata con successo.");
        }
        else {
            console.log("Nessun file trovato. Creazione di una nuova libreria.");
        }
    }
}
function writeBook() {
    let title = readline.question("Inserisci il titolo del libro: ");
    while (title === null || title === undefined || title.trim() === "" || title.length >= 50) {
        console.log("Titolo non valido, riprova.");
        title = readline.question("Inserisci il titolo del libro: ");
    }
    let author = readline.question("Inserisci l'autore del libro: ");
    while (author === null || author === undefined || author.trim() === "" || author.length >= 20) {
        console.log("Autore non valido, riprova.");
        author = readline.question("Inserisci l'autore del libro: ");
    }
    let pages = Number(readline.question("Inserisci le pagine del libro: "));
    while (isNaN(pages) || pages <= 0 || !Number.isInteger(pages) || pages >= 10000) {
        console.log("Dato non valido, riprova.");
        pages = Number(readline.question("Inserisci le pagine del libro: "));
    }
    let publishedYear = Number(readline.question("Inserisci l'anno di pubblicazione del libro, non e' possibile inserire una data antecedente al 1000: "));
    while (isNaN(publishedYear) || publishedYear <= 0 || !Number.isInteger(publishedYear) || publishedYear.toString().length != 4 || publishedYear > library1.currentYear) {
        console.log("Dato non valido, riprova.");
        publishedYear = Number(readline.question("Inserisci l'anno di pubblicazione del libro: "));
    }
    let isbn = Number(readline.question("Inserisci il codice ISBN del libro di 4 cifre: "));
    while (isNaN(isbn) || isbn <= 0 || isbn.toString().length != 4 || !Number.isInteger(isbn)) {
        console.log("Dato non valido, riprova.");
        isbn = Number(readline.question("Inserisci il codice ISBN del libro: "));
    }
    let genre = readline.question("Inserisci il genere del libro (Avventura, Horror, Romantico): ");
    while (genre.toLowerCase() != 'avventura' && genre.toLowerCase() != 'horror' && genre.toLowerCase() != 'romantico') {
        console.log("Genere non valida, riprova.");
        genre = readline.question("Inserisci il genere del libro (Avventura, Horror, Romantico): ");
    }
    let publisher = readline.question("Inserisci l'editore del libro: ");
    while (publisher === null || publisher === undefined || publisher.trim() === "" || publisher.length >= 20) {
        console.log("Editore non valido, riprova.");
        publisher = readline.question("Inserisci l'editore del libro: ");
    }
    const book = new Book(title, author, pages, publishedYear, genre, publisher, isbn, 1);
    library1.add(book);
    console.log(`Il libro "${title}" e' stato aggiunto alla libreria.`);
}
function writeComics() {
    let title = readline.question("Inserisci il titolo del fumetto: ");
    while (title === null || title === undefined || title.trim() === "" || title.length >= 50) {
        console.log("Titolo non valido, riprova.");
        title = readline.question("Inserisci il titolo del fumetto: ");
    }
    let author = readline.question("Inserisci l'autore del fumetto: ");
    while (author === null || author === undefined || author.trim() === "" || author.length >= 20) {
        console.log("Autore non valido, riprova.");
        author = readline.question("Inserisci l'autore del fumetto: ");
    }
    let pages = Number(readline.question("Inserisci le pagine del fumetto: "));
    while (isNaN(pages) || pages <= 0 || !Number.isInteger(pages) || pages >= 10000) {
        console.log("Dato non valido, riprova.");
        pages = Number(readline.question("Inserisci le pagine del fumetto: "));
    }
    let publishedYear = Number(readline.question("Inserisci l'anno di pubblicazione del fumetto: "));
    while (isNaN(publishedYear) || publishedYear <= 0 || publishedYear.toString().length != 4 || !Number.isInteger(publishedYear) || publishedYear > library1.currentYear) {
        console.log("Dato non valido, riprova.");
        publishedYear = Number(readline.question("Inserisci l'anno di pubblicazione del fumetto: "));
    }
    let isbn = Number(readline.question("Inserisci il codice ISBN di 4 cifre del fumetto: "));
    while (isNaN(isbn) || isbn <= 0 || isbn.toString().length != 4 || !Number.isInteger(isbn)) {
        console.log("Dato non valido, riprova.");
        isbn = Number(readline.question("Inserisci il codice ISBN del fumetto: "));
    }
    let publisher = readline.question("Inserisci l'editore del fumetto: ");
    while (publisher === null || publisher === undefined || publisher.trim() === "" || publisher.length >= 20) {
        console.log("Editore non valido, riprova.");
        publisher = readline.question("Inserisci l'editore del fumetto: ");
    }
    const color = readline.keyInYNStrict("Il fumetto e' a colori? (Y/N): ");
    let type = readline.question("Inserisci la tipologia del fumetto (Manga, Manwha, Comics): ");
    while (type.toLowerCase() != 'manga' && type.toLowerCase() != 'manwha' && type.toLowerCase() != 'comics') {
        console.log("Tipologia non valida, riprova.");
        type = readline.question("Inserisci la tipologia del fumetto (Manga, Manwha, Comics): ");
    }
    let volume = Number(readline.question("Inserisci il volume del fumetto: "));
    while (isNaN(volume) || volume <= 0 || !Number.isInteger(volume) || volume >= 1000) {
        console.log("Dato non valido, riprova.");
        volume = Number(readline.questionInt("Inserisci il volume del fumetto: "));
    }
    const comics = new Comics(type, title, volume, author, pages, color, publishedYear, isbn, publisher, 1);
    library1.add(comics);
    console.log(`Il fumetto "${title}" e' stato aggiunto alla libreria.`);
}
//Creazione Libri
const book1 = new Book('Il Signore degli Anelli', 'Tolkien', 1400, 1950, 'Fantasy', 'Bonpani', 8657, 1);
const book2 = new Book('Onyx storm', 'Rebecca Yarros', 640, 2025, 'Fantasy', 'Sperling & Kupfer', 1234, 1);
const book3 = new Book('Iron Flame', 'Rebecca Yarros', 672, 2025, 'Avventura', 'Bonpani', 6546, 1);
//Creazione Fumetti
const comics1 = new Comics('Manga', 'One Piece', 1, 'Eiichiro Oda', 78, false, 1995, 3243, 'Star Comics', 1);
const comics2 = new Comics('Manwha', 'Solo Leveling', 1, 'Chugong', 140, true, 2020, 2345, 'Star Comics', 1);
const comics3 = new Comics('Manga', 'One Piece', 2, 'Eiichiro Oda', 78, false, 1995, 6453, 'Star Comics', 1);
//Creazione Libreria
const library1 = new Library();
//Aggiungi Libri alla Libreria
library1.add(book1);
library1.add(book2);
library1.add(book3);
library1.add(book3);
library1.add(book2);
library1.add(book2);
//Aggiungi Comics alla Libreria
library1.add(comics1);
library1.add(comics2);
library1.add(comics3);
library1.add(comics2);
library1.add(comics2);
function main() {
    const filePath = "libreria.json";
    library1.loadFromFile(filePath);
    console.log("\nBenvenuto ad AltenLibrary!");
    let exit = false;
    while (!exit) {
        console.log("\nCosa vuoi fare?");
        console.log("1. Aggiungi Libro");
        console.log("2. Cerca Libro");
        console.log("3. Prestito/Reso");
        console.log("4. Elimina un libro");
        console.log("5. Guarda la libreria");
        console.log("6. Esci");
        const choice = Number(readline.question("Inserisci il numero dell'opzione: "));
        switch (choice) {
            case 1:
                console.log("\n1. Libro");
                console.log("2. Fumetto");
                const addChoice = Number(readline.question("Cosa vuoi creare? (premi 0 per annullare): "));
                if (addChoice === 1) {
                    writeBook();
                }
                else if (addChoice === 2) {
                    writeComics();
                }
                else {
                    console.log("Operazione annullata.");
                }
                break;
            case 2:
                console.log("\n1. Cerca per ISBN");
                console.log("2. Cerca per Autore");
                console.log("3. Cerca per Titolo");
                console.log("4. Cerca per Anno di Pubblicazione");
                const searchChoice = Number(readline.question("Che tipo di ricerca vuoi fare? (premi 0 per annullare): "));
                if (searchChoice === 1) {
                    library1.printLibrary();
                    const result = library1.findBooksByIsbn();
                    if (result) {
                        console.log(result.printBookInfo());
                    }
                    else {
                        console.log("Nessun ISBN trovato");
                    }
                }
                else if (searchChoice === 2) {
                    library1.printLibrary();
                    const result = library1.findBooksByAuthor();
                    if (result.length > 0) {
                        result.forEach(element => {
                            console.log(element.printBookInfo());
                        });
                    }
                    else {
                        console.log("Nessun autore trovato.");
                    }
                }
                else if (searchChoice === 3) {
                    library1.printLibrary();
                    const result = library1.findBooksByTitle();
                    if (result.length > 0) {
                        result.forEach(element => {
                            console.log(element.printBookInfo());
                        });
                    }
                    else {
                        console.log("Nessun titolo trovato.");
                    }
                }
                else if (searchChoice === 4) {
                    library1.printLibrary();
                    const result = library1.findBooksByPublishedYear();
                    if (result.length > 0) {
                        result.forEach(element => {
                            console.log(element.printBookInfo());
                        });
                    }
                    else {
                        console.log("Nessun anno trovato.");
                    }
                }
                else {
                    console.log("Operazione annullata.");
                }
                break;
            case 3:
                console.log("\n1. Prendi un libro");
                console.log("2. Restituisci un libro");
                const prestResChoice = Number(readline.question("Cosa vuoi fare? (premi 0 per annullare): "));
                if (prestResChoice === 1) {
                    library1.printLibrary();
                    library1.checkoutBook();
                }
                else if (prestResChoice === 2) {
                    library1.printLibrary();
                    library1.returnBook();
                }
                else {
                    console.log("Operazione annullata.");
                }
                break;
            case 4:
                library1.printLibrary();
                library1.deleteABook();
                break;
            case 5:
                library1.printLibrary();
                break;
            case 6:
                exit = true;
                break;
            default:
                console.log("Opzione non valida. Riprova.");
        }
        if (!exit) {
            const cont = readline.keyInYNStrict("Vuoi continuare? (Y/N): ");
            if (!cont) {
                exit = true;
            }
        }
    }
    library1.saveToFile(filePath);
    console.log("Grazie per aver usato AltenLibrary!");
}
main();
/*
library1.add(book1);
library1.add(book1);
library1.add(book1);
library1.printLibrary();
console.log(library1.checkoutBook(book1));
console.log(library1.checkoutBook(book1));
console.log(library1.checkoutBook(book1));
library1.printLibrary();
console.log(library1.returnBook(book1));
library1.printLibrary(); */
//Stampa Libreria
//library1.printLibrary();
/* //Preleva Libro
console.log(library1.checkoutBook(book1)); */
/* //Stampa e trova i Libri per Autore
const result = library1.findBooksByAuthor();
result.forEach(element => {
    console.log(element.printBookInfo());
});
 */
//Stampa e trova i Libri per ISBN
/* const result = library1.findBooksByIsbn(12);
if (result) {
    console.log(result.printBookInfo());
} else {
    console.log("Nessun libro trovato");
} */
/*
//Funzione per aggiungere un libro
//writeComics();
*/ 
