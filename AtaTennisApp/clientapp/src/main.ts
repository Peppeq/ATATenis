import Vue from "vue";
// @ts-ignore
import ShardsVue from "shards-vue";

// styles
import "bootstrap/dist/css/bootstrap.css";
import "shards-ui/dist/css/shards.css";

// core
import App from "./App.vue";

// layouts
import Layout from "./components/layout/AppLayout.vue";

// components
import Notifications from "vue-notification";
// @ts-ignore
import Spinner from "vue-spinkit";
import LoadingButton from "./components/elements/loading-button.vue";

// plugins
import { router } from "./router";
import { i18n } from "./plugins/i18n";
import { store } from "./store/indexx";

// tests
import "./scripts/testsJs.ts";

// css
import "./styles/global.scss";

Vue.config.productionTip = false;

Vue.component("app-layout", Layout);
Vue.component("Spinner", Spinner);
Vue.component("loading-button", LoadingButton);

Vue.use(ShardsVue);
Vue.use(Notifications);

new Vue({
	router,
	store,
	i18n,
	// eslint-disable-next-line @typescript-eslint/explicit-function-return-type
	render: h => h(App)
}).$mount("#app");
