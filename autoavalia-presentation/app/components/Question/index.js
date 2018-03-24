import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Progress from '../Progress';
import Storage from './../../helpers/storage'
import {fetchQuestion, fetchAnswer} from './../../actions/index';

export default class Question extends Component {
	constructor(props) {
		super(props);

		console.log(this.props.match.params.id);

		this.state = {
			currentQuestion: undefined,
			value: false,
			photo: undefined
		}

		this.setValue = this.setValue.bind(this);
	}

	setValue(e){
		this.setState({value: e.target.dataset.value}, () =>{
			if (this.state.value){
				this.answerQuestion();
			}
		});
	}

	answerQuestion(){
		let _model = {
			questionaryId: this.props.match.params.questionary,
			questionId: this.props.match.params.id,
			value: this.state.value,
			photo: this.state.photo
		}

		fetchAnswer(_model, (response) =>{
			console.log(response);
		});
	}


	componentWillMount() {
		let _this = this;
		fetchQuestion(this.props.match.params.questionary, this.props.match.params.id, (response) => {
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
										<button className="button button--choose" data-value={true} onClick={this.setValue}>Sim</button>
										<button className="button button--choose" data-value={false} onClick={this.setValue}>Não</button>
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