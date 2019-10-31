import { extend, configure } from "vee-validate";
import { required, email } from "vee-validate/dist/rules";
import { i18n } from "./i18n";

// Add the required rule
extend("required", { ...required, message: (_, values): string => i18n.t("validations.required", values).toString() });

// Add the email rule
extend("email", email);

// configure({
// 	// this will be used to generate messages.
// 	defaultMessage: (_, values) => i18n.t(`validations.${values._rule_}`, values)
// });
