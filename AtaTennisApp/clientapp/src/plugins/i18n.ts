import Vue from "vue";
import VueI18n from "vue-i18n";

Vue.use(VueI18n);

const dateTimeFormats: VueI18n.DateTimeFormats = {
  en: {
    short: {
      year: "numeric",
      month: "short",
      day: "numeric"
    },
    long: {
      year: "numeric",
      month: "short",
      day: "numeric",
      weekday: "short",
      hour: "numeric",
      minute: "numeric",
      hour12: true
    }
  },
  sk: {
    short: {
      year: "numeric",
      month: "numeric",
      day: "numeric"
    },
    long: {
      year: "numeric",
      month: "long",
      day: "numeric",
      weekday: "long",
      hour: "numeric",
      minute: "numeric"
    }
  }
};

const numberFormat: VueI18n.NumberFormat = {
  currency: {
    style: "currency",
    currency: "EUR"
  },
  percent: {
    style: "percent"
  }
};

const numberFormats: VueI18n.NumberFormats = {
  en: numberFormat,
  sk: numberFormat
};

export const i18n: VueI18n = new VueI18n({
  locale: "en",
  fallbackLocale: "en",
  messages: {
    en: {
      tournament: "Tournament | Tournaments",
      rank: "Rankings",
      rankings: "Rankings",
      player: "Player | Players",
      error: "Error",
      language: "Language",
      errorMessageGeneral: "There is an error in our application, reload or contact us.",
      year: "Year",
      type: "Type",
      all: "All",
      calendar: "Calendar",
      login: "Login",
      password: "Password",
      username: "User name",
      point: "Point | Points",
      create: "Create",
      place: "Place",
      draw: "Draw",
      detail: "Detail | Details",

      // player page
      name: "Name",
      surname: "Surname",
      age: "Age",
      height: "Height",
      weight: "Weight",
      residence: "Residence",
      racquet: "Racquet",
      favSurface: "Favourite surface",
      favAtpPlayer: "Favourtie ATP player",
      titles: "Titles",
      finalist: "Finalist",
      startedPlaying: "Playing tennis from",
      startedAta: "Tourned ATA",
      bio: "Bio",
      title: "Titul | Tituly",
      start: "Start",
      end: "End",

      // sentences -----------------------------------------
      usernameRequired: "Username is required",
      passwordRequired: "Password is required",
      nearestTournament: "Nearest Tournament",
      noTournament: "Currently no tournament :(",
      saveChanges: "Save changes",
      newPlayer: "New player",
      newTournament: "New tournament",

      // enums translations --------------------------------
      tournamentType0: "Grandslam",
      tournamentType1: "ATA",
      tournamentType2: "Challanger",
      tournamentType3: "ATA Special",
      tournamentType4: "Challanger Special",

      tournamentCategory0: "Singles",
      tournamentCategory1: "Doubles",

      playingSystem0: "Complete",
      playingSystem1: "Prince",
      playingSystem2: "Kombi",
      playingSystem3: "Group",

      ballsType0: "Slazenger",
      ballsType1: "Dunlop All Court",
      ballsType2: "Wilson US Open",
      ballsType3: "Wilson Australian Open",

      DrawType0: "Playoff",
      DrawType1: "Group",

      surfaceType0: "Clay",
      surfaceType1: "Grass",
      surfaceType2: "Hard",

      forehandType0: "Right-handed",
      forehandType1: "Left-handed",

      backhandType0: "One-handed",
      backhandType1: "Two-handed",

      // validations messages --------------------------------
      validations: {
        required: "{_field_} is required"
      }
    },
    sk: {
      tournament: "Turnaj | Turnaje",
      rank: "Poradie",
      rankings: "Rebríčky",
      player: "Hráč | Hráči",
      error: "Chyba",
      language: "Jazyk",
      errorMessageGeneral: "V aplikácii nastala chyba, načítajte znova alebo nás kontaktujte.",
      year: "Rok",
      type: "Typ",
      all: "Všetky",
      calendar: "Kalendár",
      login: "Prihlásenie",
      password: "Heslo",
      username: "Užívateľské meno",
      point: "Bod | Body",
      create: "Vytvoriť",
      place: "Miesto",
      start: "Začiatok",
      end: "Koniec",
      draw: "Pavúk",
      detail: "Detail | Detaily",

      // player page
      name: "Meno",
      surname: "Priezvisko",
      age: "Vek",
      height: "Výška",
      weight: "Váha",
      residence: "Bydlisko",
      racquet: "Raketa",
      favSurface: "Obľúbený povrch",
      favAtpPlayer: "Obľúbený ATP hráč",
      titles: "Tituly",
      finalist: "Finalista",
      startedPlaying: "Tenis od",
      startedAta: "Okruh ATA od",
      bio: "Biografia",
      title: "Titul | Tituly",

      // sentences -----------------------------------------
      usernameRequired: "Užívateľské meno je povinné",
      passwordRequired: "Heslo je povinné",
      nearestTournament: "Najbližší trunaj",
      noTournament: "Momentálne žiaden turnaj :(",
      saveChanges: "Uložiť zmeny",
      newPlayer: "Nový hráč",
      newTournament: "Nový turnaj",
      // enums translations --------------------------------
      tournamentType3: "ATA Špeciál",

      surfaceType0: "Antuka",
      surfaceType1: "Tráva",
      surfaceType2: "Betón",

      tournamentCategory0: "Dvojhra",
      tournamentCategory1: "Štvorhra",

      DrawType0: "Playoff",
      DrawType1: "Skupiny",

      forehandType0: "Pravák",
      forehandType1: "Ľavák",

      backhandType0: "Jednoručný",
      backhandType1: "Obojručný",

      // validations messages --------------------------------
      validations: {
        required: "{_field_} je povinné"
      }
    }
  },
  dateTimeFormats: dateTimeFormats,
  numberFormats: numberFormats
});
