<template>
	<d-navbar toggleable="md" type="dark" theme="primary" fixed="top">
		<d-navbar-toggle target="nav-collapse"></d-navbar-toggle>
		<d-navbar-brand tag="a" to="/">
			<!-- <d-nav-item > -->
			<h6 class="text-white my-auto mr-4 nav-link">ATA Tenis</h6>
			<!-- </d-nav-item> -->
		</d-navbar-brand>
		<d-collapse id="nav-collapse" is-nav>
			<d-navbar-nav :justified="true">
				<d-nav-item to="/tournamentList">{{ $tc("tournament", 0) }}</d-nav-item>
				<d-nav-item to="/tournament">{{ $tc("tournament", 1) }}</d-nav-item>
				<d-nav-item to="/">{{ $t("rankings") }}</d-nav-item>
				<d-nav-item to="/players">{{ $tc("player", 1) }}</d-nav-item>
			</d-navbar-nav>
		</d-collapse>
		<d-form-select
			v-model="selectedLanguage"
			:options="languages"
			class="language-select float-right"
			@change="onChangeLang($event)"
		/>
	</d-navbar>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class MainNavbar extends Vue {
	navbarIsJustified: boolean = true;
	languages: string[] = ["EN", "SK"];
	selectedLanguage: string = null;

	mounted() {
		this.selectedLanguage = this.languages[0];
	}
	onChangeLang(language: string): void {
		this.$i18n.locale = language.toLowerCase();
	}
}
</script>
<style>
@import "main-navbar.css";
</style>
