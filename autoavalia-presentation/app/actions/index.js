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
  return axios.get(config.api + 'api/Answer/' + questionaryId + '/' + clusterId)
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
