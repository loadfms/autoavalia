import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Card from '../Card';
import {fetchQuestionnaire} from './../../actions/index';
import Storage from './../../helpers/storage';
import {withRouter} from 'react-router-dom';


export default class Panel extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: [],
			totalDone: undefined,
			totalSteps: undefined
		}

		this.handleCardClusterClick = this.handleCardClusterClick.bind(this);
	}

	componentWillMount() {
		let _this = this;
		let _totalDone = 0;
		let _totalToDo = 0;

		fetchQuestionnaire(1, 1, (response) => {
			for (let index = 0; index < response.data.ClusterList.length; index++) {
				const element = response.data.ClusterList[index];
				_totalDone += element.QuestionsAnswered;
				_totalToDo += element.Questions;
			}
			_this.setState({
				items: response.data
			});
			Storage.setStore(response.data);
		});

		this.setState({
			totalDone: _totalDone,
			totalToDo: _totalToDo
		});
	}

	handleCardClusterClick(id) {
		this.props.history.push('/questao/' + id);
	}

	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--total-progress">
						<Card title={"Avaliação do veículo"} type={"inside"} cluster={"total-progress"} filledSteps={this.state.totalDone} totalSteps={this.state.totalToDo} progress={true} />
					</section>
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
								<Card title={"Histórico do veículo"} description={"Dados de documentação e uso"} cluster={"historic"} filledSteps={1} totalSteps={1} progress={true} />
								{
									this.state.items && this.state.items.ClusterList ?
										this.state.items.ClusterList.map((item) => {
											return (
												<Card key={item.Name} title={item.Name} description={item.Description} cluster={item.Alias} filledSteps={item.QuestionsAnswered} totalSteps={item.Questions} onClick={() => this.handleCardClusterClick(item.Id)} progress={true} />
											)
										})
										: null
								}
							</div>
						</div>
					</section>
					<button className="button button--success">Continuar</button>
				</main>
				<Footer />
			</div>
		);
	}
}