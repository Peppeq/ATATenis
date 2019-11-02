<template>
	<d-container class="main-container">
		<d-row class="main-row">
			<main-sidebar v-if="isDashboard && isAdmin" />
			<main
				v-if="isDashboard && isAdmin"
				class="main-content offset-lg-2 offset-md-3 p-0 col-sm-12 col-md-9 col-lg-10"
			>
				<admin-navbar />
				<slot v-if="isDashboard" />
			</main>
			<d-col class="main-col">
				<main-navbar v-if="isMainNavbar && !isDashboard" />
				<slot v-if="!isDashboard" />
			</d-col>
		</d-row>
		<!-- Main Footer -->
		<!-- <main-footer /> -->
		<!-- </d-col>
            <d-col cols="12" md="4" sm="1">
                <slot/>
    </d-col>-->
		<!-- </d-row> -->
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
	isCollapsedSidebar: boolean = true;

	get isAdmin(): boolean {
		return Authorization.isAdmin();
	}

	// set isAdmin() {
	// 	false;
	// }

	get isMainNavbar() {
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
<style lang="scss" scoped></style>
