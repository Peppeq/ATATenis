<template>
	<div id="app">
		<app-layout>
			<router-view />
		</app-layout>
		<notifications position="top center"></notifications>
		<main-footer v-if="!isNotMainPage" />
	</div>
</template>
<script lang="ts">
import Vue from "vue";
import MainFooter from "./components/layout/MainFooter.vue";
import { Component } from "vue-property-decorator";

const dashboard = "dashboard";
// only for admin yet
const login = "admin";

@Component({
	components: { MainFooter }
})
export default class App extends Vue {
	get isNotMainPage(): boolean {
		return this.$route.path.includes(dashboard) || this.$route.path.includes(login);
	}

	created() {
		// let fontawesome = document.createElement("script");
		// fontawesome.setAttribute("src", "https://kit.fontawesome.com/a8081aacd9.js");
		// fontawesome.setAttribute("crossorigin", "anonymous");
		// document.head.appendChild(fontawesome);
	}

	// @Ref() provider!: InstanceType<typeof ValidationProvider>;
}
</script>
