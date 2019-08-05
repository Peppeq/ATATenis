import Vue from "vue";
import { NotificationUtils } from "./notification";

export abstract class BaseComponentClass extends Vue {
    public static showError(message: string): void {
        NotificationUtils.ShowErrorMessage("V aplikácii nastala chyba, načítajte znova alebo nás kontaktujte.");
    }
}