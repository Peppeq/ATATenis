/* eslint-disable @typescript-eslint/explicit-function-return-type */
import Vue from "vue";
import Router from "vue-router";
import { Authorization } from "./common/authorization";

Vue.use(Router);

export const router = new Router({
	mode: "history",
	linkActiveClass: "active",
	routes: [
		{
			path: "/",
			name: "home",
			component: () => import("./views/Home.vue")
		},
		{
			path: "/about",
			name: "about",
			// route level code-splitting
			// this generates a separate chunk (about.[hash].js) for this route
			// which is lazy-loaded when the route is visited.
			component: () => import(/* webpackChunkName: "about" */ "./views/About.vue")
		},
		{
			path: "/rankings",
			name: "Rankings",
			component: () => import("./views/Rankings.vue")
		},
		{
			path: "/tournament/:id",
			name: "Tournament",
			component: () => import("./views/Tournament.vue"),
			props: true
		},
		{
			path: "/admin",
			name: "Admin",
			component: () => import("./views/user/Login.vue")
		},
		{
			path: "/player/:id",
			name: "Player",
			component: () => import("./views/Player.vue"),
			props: true
		},
		{
			path: "/register",
			name: "Register",
			component: () => import("./views/user/Register.vue")
		},
		{
			path: "/dashboard/playerManagement",
			name: "PlayerManagement",
			component: () => import("./views/dashboard/player-management.vue")
			// children: [
			// 	{
			// 		path: "/dashboard/tournamentManagement",
			// 		name: "TournamentManagement",
			// 		component: () => import("./views/dashboard/tournament-management.vue")
			// 	}
			// ]
		},
		{
			path: "/dashboard/tournamentManagement",
			name: "TournamentManagement",
			component: () => import("./views/dashboard/tournament-management.vue")
		},
		{
			path: "/tournamentList",
			name: "TournamentList",
			component: () => import("./views/TournamentList.vue")
		},
		{
			path: "/test",
			name: "testName",
			component: () => import("./views/test.vue")
		},
		// otherwise redirect to home
		{ path: "*", redirect: "/" }
	]
});

router.beforeEach((to, from, next) => {
	// redirect to admin page if not logged in and trying to access a restricted page
	const privatePages = ["dashboard", "register"];
	var pathLevels = to.path.split("/");
	const authRequired = privatePages.includes(pathLevels[1]);

	if (authRequired && !Authorization.isAdmin()) {
		return next("/admin");
	}

	next();
});
