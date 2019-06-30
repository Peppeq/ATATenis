import Vue from 'vue'
import ShardsVue from 'shards-vue'

//styles
import 'bootstrap/dist/css/bootstrap.css'
import 'shards-ui/dist/css/shards.css'

//core
import App from './App.vue'
import router from './router'

// Layouts
import Layout from './views/AppLayout.vue';

//tests
import './../scripts/testsJs.js'

Vue.config.productionTip = false

Vue.component('app-layout', Layout)
Vue.use(ShardsVue);

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')