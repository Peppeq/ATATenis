<template>
	<d-container class="main-container">
		<d-row class="main-row">
			<main-sidebar v-if="isDashboard && isAdmin" />
			<main
				v-if="isDashboard && isAdmin"
				class="main-content admin-container offset-lg-2 offset-md-3 p-0 col-sm-12 col-md-9 col-lg-10"
			>
				<admin-navbar />
				<slot v-if="isDashboard" />
			</main>
			<d-col class="main-col">
				<main-navbar v-if="isMainNavbar && !isDashboard" />
				<slot v-if="!isDashboard" />
			</d-col>
		</d-row>

		<div class="push mt-4" />
	</d-container>
</template>

<script lang="ts">
import mainNavbar from "./MainNavbar.vue";
import adminNavbar from "./AdminNavbar.vue";
import mainSidebar from "./MainSidebar.vue";
import { Component, Vue } from "vue-property-decorator";
import { Authorization } from "../../common/authorization";

const dashboard = "dashboard";

@Component({
	components: { mainNavbar, mainSidebar, adminNavbar }
})
export default class AppLayout extends Vue {
	private isAdminLogged: boolean;
	// mounted() {
	// 	this.isAdmin = Authorization.isAdmin();
	// }
	isCollapsedSidebar = true;

	get isAdmin(): boolean {
		return Authorization.isAdmin();
	}

	// set isAdmin() {
	// 	false;
	// }

	get isMainNavbar(): boolean {
		return this.$route.name != "Admin";
	}

	get isDashboard(): boolean {
		return this.$route.path.includes(dashboard);
	}

	menu: {}[] = [
		{
			header: true,
			title: "Main Navigation",
			hiddenOnCollapse: true
		},
		{
			href: "/dashboard",
			title: "Dashboard",
			icon: "fa fa-user"
		},
		{
			href: "/charts",
			title: "Charts",
			icon: "fa fa-chart-area",
			child: [
				{
					href: "/charts/sublink",
					title: "Sub Link"
				}
			]
		}
	];
}
</script>
<style lang="scss" scoped>
%container-shared {
	min-height: 100%;
	height: auto !important;
}

.push {
	height: 3.75rem;
}
.main-container {
	margin: 0 auto -5.25rem;
	@extend %container-shared;
}

.admin-container {
	margin-bottom: -5.25rem;
	@extend %container-shared;
}
</style>
