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

			// sentences -----------------------------------------
			usernameRequired: "Username is required",
			passwordRequired: "Password is required",

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

			BallsType0: "Slazenger",
			BallsType1: "Dunlop All Court",
			BallsType2: "Wilson US Open",
			BallsType3: "Wilson Australian Open",

			DrawType0: "Playoff",
			DrawType1: "Group",

			surfaceType0: "Clay",
			surfaceType1: "Grass",
			surfaceType2: "Hard"
		},
		sk: {
			tournament: "Turnaj | Turnaje",
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

			// sentences -----------------------------------------
			usernameRequired: "Užívateľské meno je povinné",
			passwordRequired: "Heslo je povinné",

			// enums translations --------------------------------
			tournamentType3: "ATA Špeciál",

			surfaceType0: "Antuka",
			surfaceType1: "Tráva",
			surfaceType2: "Betón",

			tournamentCategory0: "Dvojhra",
			tournamentCategory1: "Štvorhra",

			DrawType0: "Playoff",
			DrawType1: "Skupiny"
		}
	},
	dateTimeFormats: dateTimeFormats,
	numberFormats: numberFormats
});
