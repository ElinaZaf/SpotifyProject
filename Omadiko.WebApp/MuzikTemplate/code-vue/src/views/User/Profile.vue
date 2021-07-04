<template>
  <b-container fluid>
    <b-row class="profile-content">
      <b-col lg="4" md="12" cols="12">
        <iq-card body-class=" profile-page">
          <template v-slot:body>
            <div class="profile-header">
              <div class="cover-container text-center">
                <b-img v-bind:src="user.profile" alt="profile-bg" rounded="circle" fluid />
                <div class="profile-detail mt-3">
                  <h3>{{user.name}}</h3>
                  <p class="text-primary">{{user.role}}</p>
                  <p>{{ user.about }}</p>
                </div>
                <div class="iq-social d-inline-block align-items-center">
                  <ul class="list-inline d-flex p-0 mb-0 align-items-center">
                    <li>
                      <a href="#" class="avatar-40 rounded-circle bg-primary mr-2 facebook"><i class="fab fa-facebook-f" aria-hidden="true"></i></a>
                    </li>
                    <li>
                      <a href="#" class="avatar-40 rounded-circle bg-primary mr-2 twitter"><i class="fab fa-twitter" aria-hidden="true"></i></a>
                    </li>
                    <li>
                      <a href="#" class="avatar-40 rounded-circle bg-primary mr-2 youtube"><i class="fab fa-youtube" aria-hidden="true"></i></a>
                    </li>
                    <li >
                      <a href="#" class="avatar-40 rounded-circle bg-primary pinterest"><i class="fab fa-pinterest-p" aria-hidden="true"></i></a>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </template>
        </iq-card>
        <iq-card headerClass="align-items-center mb-0">
           <template v-slot:headerTitle>
              <h4 class="card-title mb-0">Personal Details</h4>
           </template>
          <template v-slot:body>
            <ul class="list-inline p-0 mb-0">
              <li v-for="(item,index) of userInfo" :key="index">
                <div class="d-flex align-items-center justify-content-between mb-3">
                  <h6>{{item.title}}</h6>
                  <p class="mb-0">{{ item.value }}</p>
                </div>
              </li>
            </ul>
          </template>
        </iq-card>
        <iq-card headerClass="align-items-center mb-0" >
          <template v-slot:headerTitle>
            <h4 class="card-title mb-0">Skill Progress</h4>
           </template>
          <template v-slot:body>
            <ul class="list-inline p-0 mb-0">
              <li v-for="(item,index) of skillProgress" :key="index">
                <div class="d-flex align-items-center justify-content-between mb-3">
                  <h6>{{ item.title }}</h6>
                  <div class="iq-progress-bar-linear d-inline-block mt-1 w-50">
                    <b-progress :value="item.value" height="6px" :variant="item.color" max="100"></b-progress>
                  </div>
                </div>
              </li>
            </ul>
          </template>
        </iq-card>
      </b-col>
      <b-col lg="8" md="12" cols="12">
        <b-row>
          <b-col md="6">
             <iq-card className="iq-card-block iq-card-stretch iq-card-height" headerClass=" align-items-center mb-0">
              <template v-slot:headerTitle>
                <h4 class="card-title mb-0">Latest Uploads</h4>
              </template>
              <template v-slot:body>
                <ul class="list-inline p-0 mb-0">
                  <li v-for="(item,index) of latestUpload" :key="index" class="d-flex mb-4 align-items-center">
                    <div class="profile-icon bg-secondary">
                      <span><i :class="item.iconClass"></i></span>
                    </div>
                    <div class="media-support-info ml-3">
                      <h6>{{ item.title }}</h6>
                      <p class="mb-0">{{ item.size }}</p>
                    </div>
                    <div class="iq-card-toolbar ml-auto">
                      <b-dropdown :id="`dropdownMenuButton${index}`" no-caret right variant="none" data-toggle="dropdown">
                        <template v-slot:button-content>
                          <span class="font-size-24"><i class="ri-more-line"></i></span>
                        </template>
                        <b-dropdown-item><i class="ri-user-unfollow-line mr-2"></i>{{ $t('dropdown.share') }}</b-dropdown-item>
                        <b-dropdown-item><i class="ri-close-circle-line mr-2"></i>{{ $t('dropdown.delete') }}</b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </li>
                </ul>
              </template>
             </iq-card>
          </b-col>
          <b-col md="6">
            <iq-card className="iq-card-block iq-card-stretch iq-card-height" headerClass=" align-items-center mb-0">
              <template v-slot:headerTitle>
                <h4 class="card-title mb-0">Top Books</h4>
              </template>
              <template v-slot:body>
                <ul class="list-inline p-0 mb-0">
                  <li v-for="(item,index) of topBooks" :key="index" >
                    <div class="iq-details mb-2">
                      <span class="title">{{ item.title }}</span>
                      <div :class="`percentage float-right text-${item.color}`">{{ item.value }} <span>%</span></div>
                      <div class="iq-progress-bar-linear d-inline-block w-100">
                        <b-progress :value="item.value" height="6px" :variant="item.color" max="100"></b-progress>
                      </div>
                    </div>
                  </li>
                </ul>
              </template>
            </iq-card>
          </b-col>
        </b-row>
        <iq-card headerClass=" align-items-center mb-0">
          <template v-slot:headerTitle>
            <h4 class="card-title mb-0">Daily Sales</h4>
          </template>
          <template v-slot:headerAction>
            <b-dropdown id="dropdownMenuButton05" right variant="none">
              <template v-slot:button-content>
                <span class="text-primary"><i class="ri-more-fill"></i></span>
              </template>
              <b-dropdown-item href="#"><i class="ri-eye-fill mr-2"></i>View</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-delete-bin-6-fill mr-2"></i>Delete</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-pencil-fill mr-2"></i>Edit</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-printer-fill mr-2"></i>Print</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-file-download-fill mr-2"></i>Download</b-dropdown-item>
            </b-dropdown>
          </template>
          <template v-slot:body>
            <ul class="perfomer-lists m-0 p-0">
              <li v-for="(item,index) of dailySales" :key="index" class="d-flex mb-4 align-items-center">
                <div class="user-img img-fluid">
                  <b-img :src="item.image" alt="image" rounded="circle" fluid class="avatar-50"/>
                </div>
                <div class="media-support-info ml-3">
                  <h5>{{ item.title }}</h5>
                  <p class="mb-0">{{ item.description }}</p>
                </div>
                <div class="iq-card-header-toolbar d-flex align-items-center ml-auto">
                  <span class="text-dark"><b>{{ item.sales }}</b></span>
                </div>
              </li>
            </ul>
          </template>
        </iq-card>
        <iq-card headerClass=" align-items-center mb-0">
          <template v-slot:headerTitle>
            <h4 class="card-title mb-0">Top Products</h4>
          </template>
          <template v-slot:headerAction>
            <b-dropdown id="dropdownMenuButton06" right variant="none">
              <template v-slot:button-content>
                <span class="text-primary"><i class="ri-more-fill"></i></span>
              </template>
              <b-dropdown-item href="#"><i class="ri-eye-fill mr-2"></i>View</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-delete-bin-6-fill mr-2"></i>Delete</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-pencil-fill mr-2"></i>Edit</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-printer-fill mr-2"></i>Print</b-dropdown-item>
              <b-dropdown-item href="#"><i class="ri-file-download-fill mr-2"></i>Download</b-dropdown-item>
            </b-dropdown>
          </template>
          <template v-slot:body>
            <ul class="perfomer-lists m-0 p-0">
              <li v-for="(item,index) of topProducts" :key="index" class="row mb-3 align-items-center justify-content-between">
                <b-col md="8">
                  <h5>{{ item.title }}</h5>
                  <p class="mb-0">{{ item.type }}</p>
                </b-col>
                <div class="col-md-4 text-right">
                  <div class="iq-card-header-toolbar d-flex align-items-center">
                    <span :class="`mr-3 text-${item.color}`"><b>+${{ item.value }}</b></span>
                    <div class="iq-progress-bar-linear d-inline-block mt-1 w-100">
                      <b-progress :value="item.value" height="6px" :variant="item.color" max="100"></b-progress>
                    </div>
                  </div>
                </div>
              </li>
            </ul>
          </template>
        </iq-card>
      </b-col>
    </b-row>
  </b-container>
</template>
<script>
import { core } from '../../config/pluginInit'
export default {
  name: 'Profile',
  components: { },
  mounted () {
    core.index()
  },
  data () {
    return {
      user: {
        profile: require('../../assets/images/user/1.jpg'),
        name: 'Barry Tech',
        role: 'Web designer',
        about: 'Phasellus faucibus mollis pharetra. Proin blandit ac massa.Morbi nulla dolor, ornare at commodo non, feugiat non nisi.'
      },
      userInfo: [
        { title: 'Birthday', value: '3rd March' },
        { title: 'Address', value: 'Londaon' },
        { title: 'Phone', value: '(010)987 543 201' },
        { title: 'Email', value: 'Barry@example.com' },
        { title: 'Twitter', value: '@Barry' },
        { title: 'Twitter', value: '@Barry_Tech' }
      ],
      skillProgress: [
        { title: 'Biography', value: '70', color: 'primary' },
        { title: 'Horror', value: '50', color: 'danger' },
        { title: 'Comic Book', value: '65', color: 'info' },
        { title: 'Adventure', value: '85', color: 'success' }
      ],
      latestUpload: [
        { title: 'Documentation', iconClass: 'ri-file-3-fill', size: '48kb' },
        { title: 'Images', iconClass: 'ri-image-fill', size: '204kb' },
        { title: 'Videos', iconClass: 'ri-video-fill', size: '509kb' },
        { title: 'Resources', iconClass: 'ri-file-3-fill', size: '48kb' },
        { title: 'Celine Dion', iconClass: 'ri-refresh-line', size: '204kb' }
      ],
      topBooks: [
        { title: 'Adventure', value: '95', color: 'primary' },
        { title: 'Horror', value: '72', color: 'warning' },
        { title: 'Comic Book', value: '75', color: 'info' },
        { title: 'Biography', value: '70', color: 'danger' },
        { title: 'Mystery', value: '80', color: 'success' }
      ],
      dailySales: [
        {
          title: 'Reading on the World',
          image: require('../../assets/images/user/06.jpg'),
          sale: '+$82',
          description: 'Lorem Ipsum is simply dummy test'
        },
        {
          title: 'Little Black Book',
          image: require('../../assets/images/user/07.jpg'),
          sale: '+$90',
          description: 'Lorem Ipsum is simply dummy test'
        },
        {
          title: 'See the More Story',
          image: require('../../assets/images/user/08.jpg'),
          sale: '+$85',
          description: 'Lorem Ipsum is simply dummy test'
        }
      ],
      topProducts: [
        {
          title: 'Find The Wave Book',
          value: '85',
          type: 'General Book',
          color: 'primary'
        },
        {
          title: 'A man with those Faces',
          value: '92',
          type: 'Biography Book',
          color: 'danger'
        }
      ]
    }
  },
  methods: {
  }
}
</script>
