import Vue from "../node_modules/vue/types/index";
import { NotificationUtils } from "./notification";

export abstract class BaseComponentClass extends Vue {
    public static showError(message: string): string {
        return NotificationUtils.ShowErrorMessage("V aplikácii nastala chyba, načítajte znova alebo nás kontaktujte.");
    }
}