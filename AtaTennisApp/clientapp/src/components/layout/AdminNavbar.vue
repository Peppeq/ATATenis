<template>
	<div :class="['main-navbar', 'bg-white', stickyTop ? 'sticky-top' : '']">
		<d-navbar type="light" class="align-items-stretch flex-md-nowrap p-0">
			<h3 class="m-auto"><i class="material-icons m-auto">dashboard</i>Dashboard</h3>
			<LanguageSelect css-class="language-select-admin" />
			<NavbarToggle />
		</d-navbar>
	</div>
</template>

<script>
// import NavbarSearch from './NavbarSearch.vue';
// import NavbarNav from './NavbarNav.vue';
import NavbarToggle from "./NavbarToggle.vue";
import LanguageSelect from "../LanguageSelect.vue";

export default {
	components: {
		// NavbarSearch,
		// NavbarNav,
		NavbarToggle,
		LanguageSelect
	},
	props: {
		/**
		 * Whether the main navbar should be sticky, or not.
		 */
		stickyTop: {
			type: Boolean,
			default: true
		}
	}
};
</script>

<style lang="scss">
.main-navbar {
	.dropdown-menu {
		display: block;
	}
}
</style>
