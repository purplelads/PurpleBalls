import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/player-management',
      name: 'player-management',
      component: () => import(/* webpackChunkName: "fetch-data" */ './views/PlayerManagement.vue'),
    },
    {
      path: '/create-shirt',
      name: 'create-shirt',
      component: () => import(/* webpackChunkName: "fetch-data" */ './views/CreateShirt.vue'),
    },
  ],
});
