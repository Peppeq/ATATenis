/* eslint-disable @typescript-eslint/explicit-function-return-type */
import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import { Authorization } from "./common/authorization";

Vue.use(Router);

export const router = new Router({
	mode: "history",
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
			path: "/dashboard",
			name: "Dashboard",
			component: () => import("./views/Dashboard.vue")
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
	const privatePages = ["/dashboard", "/register"];
	const authRequired = privatePages.includes(to.path);

	if (authRequired && !Authorization.isAdmin()) {
		return next("/admin");
	}

	next();
});
