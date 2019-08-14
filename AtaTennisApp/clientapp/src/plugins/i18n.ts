import Vue from "vue";
import VueI18n from "vue-i18n";

Vue.use(VueI18n);

const dateTimeFormats: VueI18n.DateTimeFormats = {
    "en": {
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
    "sk": {
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
        style: "currency", currency: "EUR"
    },
    percent: {
        style: "percent"
    }
};

const numberFormats: VueI18n.NumberFormats = {
    "en": numberFormat,
    "sk": numberFormat
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
            errorMessageGeneral: "There is an error in our application, reload or contact us."
        },
        sk: {
            tournament: "Turnaj | Turnaje",
            rankings: "Rebríčky",
            player: "Hráč | Hráči",
            error: "Chyba",
            language: "Jazyk",
            errorMessageGeneral: "V aplikácii nastala chyba, načítajte znova alebo nás kontaktujte."

        }
    },
    dateTimeFormats: dateTimeFormats,
    numberFormats: numberFormats
});