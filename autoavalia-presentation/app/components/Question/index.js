import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Progress from '../Progress';
import Storage from './../../helpers/storage'
import {fetchQuestion} from './../../actions/index';

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
		let _this = this;
		fetchQuestion(1, 1, this.props.match.params.id, (response) => {
			_this.setState({
				currentQuestion: response.data
			});
		});
	}

	render() {
		if (this.state.currentQuestion) {
			return (
				<div className="page page--question">
					<Header />
					<main className="main">
						<Progress filledSteps={0} totalSteps={1} />
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