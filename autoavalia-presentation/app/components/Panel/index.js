import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Card from '../Card';
import {fetchCluster} from './../../actions/index';
import Storage from './../../helpers/storage'

export default class Panel extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: []
		}
	}


	componentWillMount() {
		let _this = this;
		fetchCluster(1, 1, (response) => {
			_this.setState({ items: response.data });
			Storage.setStore(response.data);
		});
	}

	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--total-progress">
						<Card title={"Avaliação do veículo"} type={"inside"} cluster={"total-progress"} filledSteps={4} totalSteps={10} />
					</section>
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
							<Card title={"Histórico do veículo"} description={"Dados de documentação e uso"} cluster={"historic"} filledSteps={1} totalSteps={1} />
								{
									this.state.items && this.state.items.clusterList ?
										this.state.items.clusterList.map((item) => {
											return (
												<Card key={item.Name} title={item.Name} description={item.Description} cluster={item.Alias} filledSteps={item.QuestionsAnswered} totalSteps={item.Questions} />
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