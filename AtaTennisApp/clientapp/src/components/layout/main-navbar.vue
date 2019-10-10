<template>
	<d-navbar toggleable="md" type="dark" theme="primary" :sticky="true">
		<d-navbar-toggle target="nav-collapse"></d-navbar-toggle>
		<d-navbar-brand tag="a" to="/">
			<!-- <d-nav-item > -->
			<img
				id="main-logo"
				class="d-inline-block align-top mr-1 nav-link"
				style="max-width: 125px;"
				src="../../assets/images/ata_logo.png"
				alt="ATA Tennis"
			/>
		</d-navbar-brand>
		<d-collapse id="nav-collapse" is-nav>
			<d-navbar-nav :justified="true">
				<d-nav-item to="/tournamentList">{{ $tc("tournament", 0) }}</d-nav-item>
				<d-nav-item to="/rankings">{{ $t("rankings") }}</d-nav-item>
				<!-- <d-nav-item to="/player">{{ $tc("player", 1) }}</d-nav-item> -->
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
<style lang="scss" scoped>
@import "@/styles/components/layouts/main-navbar.scss";
</style>
