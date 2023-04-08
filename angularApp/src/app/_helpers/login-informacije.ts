

export class LoginInformacije {
  autentifikacijaToken:        AutentifikacijaToken=null;
  isLogiran:                   boolean=false;
}

export interface AutentifikacijaToken {
  id:                   number;
  vrijednost:           string;
  korisnickiNalogId:    number;
  korisnickiNalog:      Korisnik;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
}

export interface Korisnik {
  id:                 number;
  ime:                string;
  prezime:            string;
  korisnickoIme:      string;
  slika_korisnika:    string;
  isAdmin:            boolean;
  isClan:         boolean;
  isTrener:            boolean;
  isOsoblje:           boolean;
}
