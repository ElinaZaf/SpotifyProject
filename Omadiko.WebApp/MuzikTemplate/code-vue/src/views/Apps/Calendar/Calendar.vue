<template>
  <b-container fluid>
    <b-row>
      <b-col md="3">
        <iq-card class="calender-small">
          <template v-slot:body>
            <input type="hidden" class="displayCalendar d-none">
            <flat-pickr :config="config" value="" class="d-none"/>
          </template>
        </iq-card>
        <iq-card>
          <template v-slot:headerTitle>
            <h4 class="card-title ">Classification</h4>
          </template>
          <template v-slot:headerAction>
            <a href="#"><i class="fa fa-plus  mr-0" aria-hidden="true" /></a>
          </template>
          <template v-slot:body>
            <ul class="m-0 p-0 job-classification">
              <li class=""><i class="ri-check-line bg-danger" />Meeting</li>
              <li class=""><i class="ri-check-line bg-success" />Business travel</li>
              <li class=""><i class="ri-check-line bg-warning" />Personal Work</li>
              <li class=""><i class="ri-check-line bg-info" />Team Project</li>
            </ul>
          </template>
        </iq-card>
        <iq-card>
          <template v-slot:headerTitle>
            <h4 class="card-title">Today's Schedule</h4>
          </template>
          <template v-slot:body>
            <ul class="m-0 p-0 today-schedule">
              <li class="d-flex">
                <div class="schedule-icon"><i class="ri-checkbox-blank-circle-fill text-primary" /></div>
                <div class="schedule-text"> <span>Web Design</span>
                  <span>09:00 to 12:00</span></div>
              </li>
              <li class="d-flex">
                <div class="schedule-icon"><i class="ri-checkbox-blank-circle-fill text-success" /></div>
                <div class="schedule-text"> <span>Participate in Design</span>
                  <span>09:00 to 12:00</span></div>
              </li>
            </ul>
          </template>
        </iq-card>
      </b-col>
      <b-col md="9">
        <iq-card>
          <template v-slot:headerTitle>
            <h4 class="card-title">Book Appointment</h4>
          </template>
          <template v-slot:headerAction>
            <button type="button" class="btn btn-primary"><i class="ri-add-line mr-2"></i>Book Appointment</button>
          </template>
          <template v-slot:body>
            <FullCalendar :options="calendarOptions" />
          </template>
        </iq-card>
      </b-col>
    </b-row>
  </b-container>
</template>
<script>
import FullCalendar from '@fullcalendar/vue'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'
import { core } from '../../../config/pluginInit'
export default {
  name: 'Calendar',
  components: { FullCalendar },
  data () {
    return {
      config: {
        dateFormat: 'Y-m-d',
        inline: true
      },
      calendarOptions: {
        plugins: [ dayGridPlugin, interactionPlugin, timeGridPlugin ],
        headerToolbar: {
          left: 'prev,next today',
          center: 'title',
          right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        initialView: 'dayGridMonth',
        events: [
          {
            title: 'All Day Event',
            start: '2020-07-01',
            color: '#fc9919'
          },
          {
            title: 'Long Event',
            start: '2020-07-07',
            end: '2020-07-10',
            color: '#ffc107'
          },
          {
            title: 'Repeating Event',
            start: '2020-07-09',
            color: '#17a2b8'
          },
          {
            title: 'Repeating Event',
            start: '2020-07-16',
            color: '#17a2b8'
          },
          {
            title: 'Conference',
            start: '2020-07-11',
            end: '2020-07-13',
            color: '#27e3f4'
          },
          {
            title: 'Lunch',
            start: '2020-07-12',
            color: '#777D74'
          },
          {
            title: 'Birthday Party',
            start: '2020-07-28',
            color: '#28a745'
          },
          {
            title: 'Birthday Party',
            start: '2020-01-02',
            color: '#28a745'
          },
          {
            title: 'Click for Google',
            url: 'http://google.com/',
            start: '2020-01-25'
          },
          {
            title: 'Birthday Party',
            start: '2020-01-13',
            color: '#28a745'
          },
          {
            title: 'Click for Google',
            url: 'http://google.com/',
            start: '2020-07-28'
          },
          {
            title: 'Birthday Party',
            start: '2020-01-13',
            color: '#28a745'
          },
          {
            title: 'Click for Google',
            url: 'http://google.com/',
            start: '2020-01-28'
          },
          {
            title: 'All Day Event',
            start: '2020-02-01',
            color: '#fc9919'
          },
          {
            title: 'Long Event',
            start: '2020-02-07',
            end: '2020-02-10',
            color: '#ffc107'
          },
          {
            title: 'Repeating Event',
            start: '2020-02-09',
            color: '#17a2b8'
          },
          {
            title: 'Repeating Event',
            start: '2020-02-16',
            color: '#17a2b8'
          }
        ]
      }
    }
  },
  mounted () {
    core.index()
  },
  computed: {
  },
  methods: {
  }
}
</script>

<style lang="css">
.fc-theme-standard .fc-toolbar .fc-button {background: var(--iq-light-primary); color: var(--iq-primary); border: none; text-transform: capitalize; border-radius: 15px; -webkit-border-radius: 15px; }
.fc-theme-standard .fc-toolbar .fc-button.fc-button-active, .fc-theme-standard .fc-toolbar .fc-button:active, .fc-theme-standard .fc-toolbar .fc-button:focus { color: var(--iq-white); background-color: var(--iq-primary); }
.fc .fc-button-primary:focus, .fc .fc-button:focus{box-shadow: none;}
</style>
