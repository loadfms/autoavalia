import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Progress from '../Progress';
import Storage from './../../helpers/storage'

export default class Question extends Component {
	constructor(props) {
		super(props);

		console.log(this.props.match.params.id);

		this.state = {
			questions: [],
			currentQuestion: undefined
		}
	}


	componentWillMount() {
		let _clusters = Storage.getStore().clusterList;
		let _maxAnswer = 0;

		console.log(_clusters);
		for (var i = 0; i < _clusters.length; i++) {
			if (_clusters[i].Id == this.props.match.params.id) {
				this.setState({
					questions: _clusters[i]
				}, () => {
					console.log(this.state.questions);
					console.log(this.state.questions.AnswerList);

					if (this.state.questions.AnswerList == 0) {
						this.setState({
							currentQuestion: this.state.questions.QuestionList[0]
						}, () => {
							console.log(this.state.currentQuestion);
						})
					} else {
						for (var i = 0; i < this.state.questions.AnswerList.length; i++) {
							if (_maxAnswer < this.state.questions.AnswerList[i].QuestionId)
								_maxAnswer = this.state.questions.AnswerList[i].QuestionId;
						}
						for (var i = 0; i < this.state.questions.length; i++) {
							if (this.state.questions[i].Id == _maxAnswer) {
								this.setState({
									currentQuestion: this.state.questions.QuestionList[i]
								}, () => {
									console.log(this.state.currentQuestion);
								});
							}
						}
					}
				});
			}
		}
	}

	render() {
		if (this.state.currentQuestion) {
			return (
				<div className="page page--question">
					<Header />
					<main className="main">
						<Progress filledSteps={this.state.questions.QuestionsAnswered} totalSteps={this.state.questions.Questions} />
						<section className="section section--question">
							<div className="container">
								<div className="question">
									<span className="question__icon">
										<span className="question__icon__image"></span>
									</span>
									<h2 className="question__title">{this.state.currentQuestion.Name}</h2>
									<p className="question__description">{this.state.currentQuestion.Description}</p>
								</div>
							</div>
						</section>
						<section className="section section--answer">
							<div className="container">
								<div className="answer">
									<div className="answer__buttons">
										<button className="button button--choose">Sim</button>
										<button className="button button--choose">Não</button>
									</div>
								</div>
							</div>
						</section>
					</main>
				</div>
			);
		} else {
			return (null);
		}
	}
}