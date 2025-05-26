import * as readline from "readline-sync";
import * as fs from "fs";

abstract class GenericBook {
  title: string;
  author: string;
  publishedYear: number;
  quantity: number;
  bookCode: number;
  abstract printBookInfo(): void;
}

class Magazine extends GenericBook {
  magazineType: string;
  constructor(
    title: string,
    author: string,
    publishedYear: number,
    quantity: number,
    magazineType: string,
    bookCode: number
  ) {
    super();
    this.title = title;
    this.author = author;
    this.publishedYear = publishedYear;
    this.quantity = quantity;
    this.magazineType = magazineType;
    this.bookCode = bookCode;
  }

  override printBookInfo() {
    console.log(
      `Titolo ${this.title}\nAutore ${this.author}\nAnno di pubblicazione ${this.publishedYear}\nQuantità ${this.quantity}\nGenere ${this.magazineType}\nCodice ${this.bookCode}\n-----------------------`
    );
  }
}

class Fumetto extends GenericBook {
  fumettoType: string;
  constructor(
    title: string,
    author: string,
    publishedYear: number,
    quantity: number,
    fumettoType: string,
    bookCode: number
  ) {
    super();
    this.title = title;
    this.author = author;
    this.publishedYear = publishedYear;
    this.quantity = quantity;
    this.fumettoType = fumettoType;
    this.bookCode = bookCode;
  }

  override printBookInfo() {
    console.log(
      `Titolo ${this.title}\nAutore ${this.author}\nAnno di pubblicazione ${this.publishedYear}\nQuantità ${this.quantity}\nGenere ${this.fumettoType},\nCodice ${this.bookCode}\n-----------------------`
    );
  }
}

class Book extends GenericBook {
  genere: string;
  constructor(
    title: string,
    author: string,
    publishedYear: number,
    quantity: number,
    genere: string,
    bookCode: number
  ) {
    super();
    this.title = title;
    this.author = author;
    this.publishedYear = publishedYear;
    this.quantity = quantity;
    this.genere = genere;
    this.bookCode = bookCode;
  }

  override printBookInfo() {
    console.log(
      `Titolo ${this.title}\nAutore ${this.author}\nAnno di pubblicazione ${this.publishedYear}\nQuantità ${this.quantity},\nGenere ${this.genere}\nCodice ${this.bookCode}\n-----------------------`
    );
  }
}

class Library {
  private books: GenericBook[] = [];

  add(b: GenericBook) {
    const existingBook = this.books.find(
      (book) => book.bookCode === b.bookCode
    );
    if (existingBook) {
      existingBook.quantity += b.quantity;
      console.log(
        `Il libro "${b.title}" è già presente nella libreria. Quantità aggiornata.`
      );
    } else {
      this.books.push(b);
    }
    return b;
  }

  remove(b: GenericBook) {
    const index = this.books.indexOf(b);
    const existingBook = this.books.find(
      (book) => book.bookCode === b.bookCode
    );
    if (existingBook) {
      existingBook.quantity -= b.quantity;
      if (existingBook.quantity <= 0) {
        this.books.splice(index, 1);
        console.log(`Il libro è stato rimosso dalla libreria.`);
      } else {
        console.log(
          `Il libro è ancora disponibile in quantità ${existingBook.quantity}.`
        );
      }
    } else {
      console.log(`Il libro non è presente nella libreria.`);
    }
    return b;
  }

  findBookByAuthor(author: string) {
    const result: GenericBook[] = this.books.filter((book: GenericBook) => {
      return book.author === author;
    });
    return result;
  }

  findBookByBookCode(code: number) {
    return this.books.find((book: GenericBook) => book.bookCode === code);
  }

  printLibrary() {
    this.books.forEach((b) => {
      b.printBookInfo();
    });
  }
}

let book1 = new Book("harry potter", "j.k. rowling", 2010, 1, "fantasy", 874);
let book2 = new Book("harry pippo", "peppe", 2010, 1, "fantasy", 322);
//book1.printBookInfo();

const filePath = "library.json"; // Percorso del file JSON
let library = loadLibraryFromFile(filePath); // Carica la libreria dal file

library.add(new Book("il curioso caso", "peppe", 1999, 1, "romanzo", 1234));
library.add(new Magazine("mimmm", "cii", 2000, 1, "moda", 99));
library.add(new Fumetto("One Piece", "uw", 2000, 1, "manga", 645));
library.add(book1);
//library.checkoutBook(book1);
library.add(book2);

//console.log(library.findBookByAuthor("peppe"));

function writeParametersBook() {
  let title: string = readline.question("Inserire Titolo: ");
  while (!title.trim() || !title) {
    console.log("Titolo non valido! Non può contenere numeri.");
    title = readline.question("Inserire titolo: ");
    let answer=  readline.question(`E' ${title} il titolo?`)
    
  }
  title = title.toLocaleLowerCase();
  let author: string = readline.question("inserire autore ");
  while (!author || !author.trim()) {
    console.log("autore non valido");
    author = readline.question("inserire autore ");
  }
  author.toLocaleLowerCase();
  let publishedYear: number = Number(
    readline.question("inserire anno di pubblicazione ")
  );
  while (
    isNaN(publishedYear) ||
    publishedYear <= 1800 ||
    publishedYear > 2025 ||
    !Number.isInteger(publishedYear)
  ) {
    console.log("anno non valido");
    publishedYear = Number(
      readline.question("inserire anno di pubblicazione ")
    );
  }

  let quantity: number = Number(readline.question("inserire quantità "));
  while (isNaN(quantity) || quantity <= 0 || !Number.isInteger(quantity)) {
    console.log("quantità non valida");
    quantity = Number(readline.question("inserire quantità "));
  }
  let genere: string = readline.question("Inserire genere: ");
  while (!genere.trim() || /\d/.test(genere)) {
    console.log("Genere non valido! Non può contenere numeri.");
    genere = readline.question("Inserire genere: ");
  }
  genere = genere.toLocaleLowerCase();
  let bookCode: number = Number(readline.question("inserire codice libro "));
  while (isNaN(bookCode) || bookCode <= 0 || !Number.isInteger(bookCode)) {
    console.log("codice non valido");
    bookCode = Number(readline.question("inserire codice libro "));
  }

  const bookN = new Book(
    title,
    author,
    publishedYear,
    quantity,
    genere,
    bookCode
  );
  library.add(bookN);
  console.log(`Il libro "${bookN.title}" è stato aggiunto alla libreria.`);
}

function writeParametersMagazine() {
  let title: string = readline.question("inserire titolo ");
  while (!title || !title.trim()) {
    console.log("titolo non valido");
    title = readline.question("inserire titolo ");
  }
  title.toLocaleLowerCase();
  let author: string = readline.question("inserire autore ");
  while (!author) {
    console.log("autore non valido");
    author = readline.question("inserire autore ");
  }
  author.toLocaleLowerCase();
  let publishedYear: number = Number(
    readline.question("inserire anno di pubblicazione ")
  );
  while (
    isNaN(publishedYear) ||
    publishedYear <= 1900 ||
    publishedYear > 2025 ||
    !Number.isInteger(publishedYear)
  ) {
    console.log("anno non valido");
    publishedYear = Number(
      readline.question("inserire anno di pubblicazione ")
    );
  }
  let quantity: number = Number(readline.question("inserire quantità "));
  while (isNaN(quantity) || quantity <= 0 || !Number.isInteger(quantity)) {
    console.log("quantità non valida");
    quantity = Number(readline.question("inserire quantità "));
  }
  let magazineType: string = readline.question("inserire genere ");
  while (!magazineType || !magazineType.trim() || /\d/.test(magazineType)) {
    console.log("genere non valido");
    magazineType = readline.question("inserire genere ");
  }
  magazineType.toLocaleLowerCase();
  let bookCode: number = Number(readline.question("inserire codice libro "));
  while (isNaN(bookCode) || bookCode <= 0 || !Number.isInteger(bookCode)) {
    console.log("codice non valido");
    bookCode = Number(readline.question("inserire codice libro "));
  }
  const magN = new Magazine(
    title,
    author,
    publishedYear,
    quantity,
    magazineType,
    bookCode
  );
  library.add(magN);
  console.log(`Il magazine "${magN.title}" è stato aggiunto alla libreria.`);
}

function writeParametersFumetto() {
  let title: string = readline.question("inserire titolo ");
  while (!title || !title.trim()) {
    console.log("titolo non valido");
    title = readline.question("inserire titolo ");
  }
  title.toLocaleLowerCase();
  let author: string = readline.question("inserire autore ");
  while (!author || !author.trim()) {
    console.log("autore non valido");
    author = readline.question("inserire autore ");
    
  }
  author.toLocaleLowerCase();
  let publishedYear: number = Number(
    readline.question("inserire anno di pubblicazione ")
  );
  while (
    isNaN(publishedYear) ||
    publishedYear <= 1900 ||
    publishedYear > 2025 ||
    !Number.isInteger(publishedYear)
  ) {
    console.log("anno non valido");
    publishedYear = Number(
      readline.question("inserire anno di pubblicazione ")
    );
  }

  let quantity: number = Number(readline.question("inserire quantità "));
  while (isNaN(quantity) || quantity <= 0 || !Number.isInteger(quantity)) {
    console.log("quantità non valida");
    quantity = Number(readline.question("inserire quantità "));
  }
  let fumettoType: string = readline.question("inserire genere ");
  while (!fumettoType || !fumettoType.trim() || /\d/.test(fumettoType)) {
    console.log("genere non valido");
    fumettoType = readline.question("inserire genere ");
  }
  fumettoType.toLocaleLowerCase();
  let bookCode: number = Number(readline.question("inserire codice libro "));
  while (isNaN(bookCode) || bookCode <= 0 || !Number.isInteger(bookCode)) {
    console.log("codice non valido");
    bookCode = Number(readline.question("inserire codice libro "));
  }
  const fumN = new Fumetto(
    title,
    author,
    publishedYear,
    quantity,
    fumettoType,
    bookCode
  );
  library.add(fumN);
  console.log(`Il fumetto "${fumN.title}" è stato aggiunto alla libreria.`);
}

function removeParametersBook() {
  let quantity: number = Number(readline.question("inserire quantità "));
  while (isNaN(quantity) || quantity <= 0 || !Number.isInteger(quantity)) {
    console.log("quantità non valida");
    quantity = Number(readline.question("inserire quantità "));
  }

  let bookCode: number = Number(readline.question("inserire codice libro "));
  while (isNaN(bookCode) || bookCode <= 0 || !Number.isInteger(bookCode)) {
    console.log("codice non valido");
    bookCode = Number(readline.question("inserire codice libro "));
  }
  const bookR = new Book("", "", 0, quantity, "", bookCode);
  library.remove(bookR);
}

function removeParametersMagazine() {
  let quantity: number = Number(readline.question("inserire quantità "));
  while (isNaN(quantity) || quantity <= 0 || !Number.isInteger(quantity)) {
    console.log("quantità non valida");
    quantity = Number(readline.question("inserire quantità "));
  }

  let bookCode: number = Number(readline.question("inserire codice libro "));
  while (isNaN(bookCode) || bookCode <= 0 || !Number.isInteger(bookCode)) {
    console.log("codice non valido");
    bookCode = Number(readline.question("inserire codice libro "));
  }
  const magR = new Magazine("", "", 0, quantity, "", bookCode);
  library.remove(magR);
}

function removeParametersFumetto() {
  let quantity: number = Number(readline.question("inserire quantità "));
  while (isNaN(quantity) || quantity <= 0 || !Number.isInteger(quantity)) {
    console.log("quantità non valida");
    quantity = Number(readline.question("inserire quantità "));
  }

  let bookCode: number = Number(readline.question("inserire codice libro "));
  while (isNaN(bookCode) || bookCode <= 0 || !Number.isInteger(bookCode)) {
    console.log("codice non valido");
    bookCode = Number(readline.question("inserire codice libro "));
  }
  const fumR = new Fumetto("", "", 0, quantity, "", bookCode);
  library.remove(fumR);
}

function saveLibraryToFile(library: Library, filePath: string) {
  const data = JSON.stringify({ books: library["books"] }, null, 2);
  fs.writeFileSync(filePath, data, "utf-8");
  console.log(`Libreria salvata nel file: ${filePath}`);
}

function loadLibraryFromFile(filePath: string): Library {
  if (!fs.existsSync(filePath)) {
    console.log("File non trovato. Verrà creata una nuova libreria.");
    return new Library();
  }

  const data = fs.readFileSync(filePath, "utf-8");
  const parsedData = JSON.parse(data);
  const library = new Library();

  parsedData.books.forEach((book: any) => {
    if (book.genere) {
      library.add(
        new Book(
          book.title,
          book.author,
          book.publishedYear,
          book.quantity,
          book.genere,
          book.bookCode
        )
      );
    } else if (book.magazineType) {
      library.add(
        new Magazine(
          book.title,
          book.author,
          book.publishedYear,
          book.quantity,
          book.magazineType,
          book.bookCode
        )
      );
    } else if (book.fumettoType) {
      library.add(
        new Fumetto(
          book.title,
          book.author,
          book.publishedYear,
          book.quantity,
          book.fumettoType,
          book.bookCode
        )
      );
    }
  });

  console.log("Libreria caricata dal file.");
  return library;
}

function main() {
  let exit = false;

  while (!exit) {
    const answer = readline.question(
      "Cosa vuoi fare?\n" +
        "a) Aggiungere un libro\n" +
        "b) Rimuovere un libro\n" +
        "c) Cercare un libro per autore\n" +
        "d) Cercare un libro per codice\n" +
        "e) Stampare la libreria\n" +
        "f) Salvare e uscire\n"
    );

    switch (answer.toLowerCase()) {
      case "a":
        const addBook = readline.question(
          "Vuoi aggiungere un libro, un fumetto o una rivista? \n" +
            "a) Libro \n" +
            "b) Rivista\n" +
            "c) Fumetto\n"
        );
        switch (addBook.toLowerCase()) {
          case "a":
            writeParametersBook();
            break;
          case "b":
            writeParametersMagazine();
            break;
          case "c":
            writeParametersFumetto();
            break;
          default:
            console.log("Risposta non valida! Riprova.");
        }
        break;

      case "b":
        const removeBook = readline.question(
          "Vuoi rimuovere un libro, un fumetto o una rivista? \n" +
            "a) Libro \n" +
            "b) Rivista\n" +
            "c) Fumetto\n"
        );
        switch (removeBook.toLowerCase()) {
          case "a":
            removeParametersBook();
            break;
          case "b":
            removeParametersMagazine();
            break;
          case "c":
            removeParametersFumetto();
            break;
          default:
            console.log("Risposta non valida! Riprova.");
        }
        break;

      case "c":
        let author = readline.question("Inserisci il nome dell'autore: ");

        while (!author) {
          console.log("Nome autore non valido");
          author = readline.question("Inserisci il nome dell'autore: ");
          author.toLocaleLowerCase();
        }
        const booksByAuthor = library.findBookByAuthor(author);
        if (booksByAuthor.length > 0) {
          console.log(
            "Libri trovati:",
            booksByAuthor.map((b) => b.title)
          );
        } else {
          console.log("Nessun libro trovato per questo autore");
        }
        break;

      case "d":
        let code = Number(readline.question("Inserisci il codice libro: "));
        while (isNaN(code) || code <= 0 || !Number.isInteger(code)) {
          console.log("Codice non valido");
          code = Number(readline.question("Inserisci il codice libro: "));
        }
        const bookByCode = library.findBookByBookCode(code);
        if (bookByCode) {
          console.log("Libro trovato:", bookByCode.title);
        } else {
          console.log("Libro non trovato");
        }
        break;

      case "e":
        library.printLibrary();
        break;

      case "f":
        saveLibraryToFile(library, filePath);
        console.log("Uscita dal programma...");
        exit = true;
        break;

      default:
        console.log("Risposta non valida! Riprova.");
    }

    if (!exit) {
      console.log("\nTorna al menu principale...\n");
    }
  }
}

main();
