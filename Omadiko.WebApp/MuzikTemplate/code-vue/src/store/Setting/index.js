import getters from './getters'
import actions from './actions'
import mutations from './mutations'

const state = {
  horizontalMenu: false,
  miniSidebarMenu: false,
  lang: { title: 'English', value: 'en', image: require('../../assets/images/small/flag-01.png') },
  langOption: [
    { title: 'English', value: 'en', image: require('../../assets/images/small/flag-01.png') },
    { title: 'Arabic', value: 'ar', image: require('../../assets/images/small/flag-500.png') },
    { title: 'Chinese', value: 'chi', image: require('../../assets/images/small/flag-300.png') },
    { title: 'Hindi', value: 'hi', image: require('../../assets/images/small/flag-100.png') },
    { title: 'Greek', value: 'gr', image: require('../../assets/images/small/flag-400.png') },
    { title: 'Franch', value: 'fr', image: require('../../assets/images/small/flag-200.png') }
  ],
  colors: [
    { primary: '#ff4545' },
    { primary: '#02d871' },
    { primary: '#309cf3' },
    { primary: '#ff00ff' },
    { primary: '#fb1f4c' },
    { primary: '#00ced1' },
    { primary: '#f35f3b' },
    { primary: '#fde117' },
    { primary: '#ff0000' },
    { primary: '#88028c' },
    { primary: '#00d5ab' },
    { primary: '#ce9252' },
    { primary: '#f9ae02' },
    { primary: '#1e7fe4' },
    { primary: '#006400' },
    { primary: '#fa7c04' },
    { primary: '#81bf02' },
    { primary: '#99a7ca' },
    { primary: '#3d2a26' },
    { primary: '#a0746b' }
  ],
  authUser: {
    auth: false,
    authType: false,
    user: {}
  },
  users: [
    {
      id: 'sh46s546sdg564sdffs4hsd6fh',
      name: 'Admin Demo',
      mobileNo: null,
      email: 'admin@demo.com',
      profileImage: null,
      password: 'admin123'
    }
  ],
  activePage: {
    name: 'Dashboard',
    breadCrumb: [
      {
        html: '<i class="ri-home-4-line mr-1 float-left"></i>Home',
        to: { name: 'dashboard.home-1' }
      },
      {
        text: '',
        href: '#'
      }
    ]
  },
  layoutMode: {
    dark: false,
    rtl: false,
    sidebar: ''
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
