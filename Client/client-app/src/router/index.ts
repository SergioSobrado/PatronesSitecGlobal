import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MenuView from '../views/GlobalView.vue'
import GlobalView from '../views/GlobalView.vue'
import AboutView from '../views/AboutView.vue'
import AdminRequests from '@/views/AdminRequests.vue'
import AdminSobrecargas from '@/views/AdminSobrecargas.vue'
import AdminGlobales from '@/views/AdminGlobales.vue'
import AdminAjustes from '@/views/AdminAjustes.vue'


Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  { 
    path: '/global',
    name: 'global',
    component: GlobalView,
    meta: {title: 'global'}
  },
  { 
    path: '/materias',
    name: 'materias',
    component: AboutView,
    meta: {title: 'materias'}
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  { 
    path: '/admin',
    name: 'admin',
    component: AdminRequests,
    meta: {title: 'AdminRequests'}
  },
  { 
    path: '/sobrecargas',
    name: 'Sobrecargas',
    component: AdminSobrecargas,
    meta: {title: 'Sobrecargas'}
  },
  { 
    path: '/globales',
    name: 'Globales',
    component: AdminGlobales,
    meta: {title: 'Globales'}
  },
  { 
    path: '/ajustes',
    name: 'Ajustes',
    component: AdminAjustes,
    meta: {title: 'Ajustes'}
  },

]

const router = new VueRouter({
  routes
})

const appTitle = "Sitec";
router.afterEach((to, from) => {
  Vue.nextTick(() => {
    document.title = `${appTitle} - ${to?.meta?.title}` || appTitle;
  });
});
export default router
