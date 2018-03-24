import axios from 'axios';
import config from './../../config/config.json'

export function fetchQuestionnaire(userId, advertiseId, callback) {
  return axios.get(config.api + 'api/Questionnaire/' + userId + '/' + advertiseId)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

export function fetchQuestion(questionaryId, clusterId, callback) {
  return axios.get(config.api + 'api/Question/' + questionaryId + '/' + clusterId)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

export function fetchReport(questionaryId, callback) {
  return axios.get(config.api + 'api/report/create/' + questionaryId)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

export function fetchAnswer(model, callback) {
  return axios.post(config.api + 'api/Answer', model)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

export function fetchPhoto(model, callback) {
  return axios.post(config.api + 'api/assets/upload', model)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

