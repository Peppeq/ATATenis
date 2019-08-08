import Vue from "vue";
import { NotificationUtils } from "./notification";
import { i18n } from "@/plugins/i18n";

interface ITryGetApiArgs<TResult, TArgs> {
    apiMethod: (args: TArgs) => Promise<TResult>;
    showError: boolean;
    requestArgs: TArgs;
}

export abstract class BaseComponentClass extends Vue {
    public async tryGetDataByArgs<TResult, TArgs>(args: ITryGetApiArgs<TResult, TArgs>): Promise<TResult> {
        let response: TResult = null;
        try {
            response = await args.apiMethod(args.requestArgs);
        } catch (e) {
            if (args.showError) {
                console.log(e);
                this.showError(i18n.t("errorMessageGeneral").toString());
            }
        }
        console.log(response);
        return response;
    }

    public showError(message: string): void {
        NotificationUtils.ShowErrorMessage(message);
    }
}