import Vue from "vue";
// @ts-ignore
import ShardsVue from "shards-vue";

// styles
import "bootstrap/dist/css/bootstrap.css";
import "shards-ui/dist/css/shards.css";

// core
import App from "./App.vue";
import router from "./router";

// layouts
import Layout from "./components/layout/AppLayout.vue";

// plugins
import Notifications from "vue-notification";
import { i18n } from "./plugins/i18n";

// tests
import "./scripts/testsJs.ts";

Vue.config.productionTip = false;

Vue.component("app-layout", Layout);
Vue.use(ShardsVue);
Vue.use(Notifications);

new Vue({
	router,
	i18n,
	// eslint-disable-next-line @typescript-eslint/explicit-function-return-type
	render: h => h(App)
}).$mount("#app");
