<template>
	<d-container class="main-container">
		<d-row class="main-row">
			<d-col class="main-col">
				<main-navbar v-if="isMainNavbar" />
				<slot />
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
import mainNavbar from "./main-navbar.vue";
import mainSidebar from "./main-sidebar.vue";
import { Component, Vue } from "vue-property-decorator";
import { Authorization } from "../../common/authorization";

@Component({
	components: { mainNavbar, mainSidebar }
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
@import "@/styles/components/layouts/main-sidebar.scss";
</style>
