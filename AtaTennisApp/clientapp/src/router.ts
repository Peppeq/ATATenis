/* eslint-disable @typescript-eslint/explicit-function-return-type */
import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";

Vue.use(Router);

export default new Router({
	mode: "history",
	routes: [
		{
			path: "/",
			name: "home",
			component: Home
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
			path: "/players",
			name: "nameeee",
			component: () => import("./views/Players.vue")
		},
		{
			path: "/tournament/:id",
			name: "Tournament",
			component: () => import("./views/Tournament.vue")
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
		}
	]
});
