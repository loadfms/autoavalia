import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Progress from '../Progress';
import Storage from './../../helpers/storage'
import { fetchQuestion, fetchAnswer, fetchPhoto } from './../../actions/index';
import { withRouter } from 'react-router-dom';

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
		this.firePhotoEvent = this.firePhotoEvent.bind(this);
	}

	firePhotoEvent(e) {
		const _file = e.target.files[0];
		let _data = new FormData();
		_data.append('UploadedImage', _file);

		fetchPhoto(_data, (response) => {
			if (response.data && response.data.Success == true){
				this.setState({photo: response.data.BlobName, value: true}, () =>{
					this.answerQuestion();
				});
			}
		})
	}

	setValue(e) {
		this.setState({ value: e.target.dataset.value, photo: 'teste' }, () => {
			console.log(this.state.value);
			if (this.state.value == "yes") {
				alert('posta a porra da foto!')
			} else {
				this.answerQuestion();
			}
		});
	}

	answerQuestion() {
		let _model = {
			QuestionnaireId: this.props.match.params.questionary,
			QuestionId: this.state.currentQuestion.Id,
			Value: this.state.value,
			Photo: this.state.photo
		}

		fetchAnswer(_model, (response) => {
			this.getCurrentQuestion();
		});
	}

	componentWillMount() {
		this.getCurrentQuestion();
	}

	getCurrentQuestion() {
		let _this = this;
		fetchQuestion(this.props.match.params.questionary, this.props.match.params.id, (response) => {
			if (response.data == null) {
				this.props.history.push('/painel');
			} else {
				_this.setState({
					currentQuestion: response.data
				});
			}
		});
	}

	render() {
		if (this.state.currentQuestion) {
			return (
				<div className="page page--question">
					<Header />
					<main className="main">
						<Progress filledSteps={0} totalSteps={1} />
						<input type="file" accept="image/*" capture="camera" onChange={this.firePhotoEvent}></input>
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
									<div className="buttons">
										<button className="button button--choose" data-value={"yes"} onClick={this.setValue}>Sim</button>
										<button className="button button--choose" data-value={"no"} onClick={this.setValue}>Não</button>
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