<template>
	<d-navbar toggleable="md" type="dark" :sticky="true">
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
				<d-nav-item to="/dashboard/playerManagement">Dashboard</d-nav-item>
			</d-navbar-nav>
		</d-collapse>
		<language-select />
	</d-navbar>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import languageSelect from "../LanguageSelect.vue";

@Component({
	components: { languageSelect }
})
export default class MainNavbar extends Vue {
	navbarIsJustified = true;
}
</script>
<style lang="scss" scoped>
@import "@/styles/components/layouts/my-main-navbar.scss";
</style>
