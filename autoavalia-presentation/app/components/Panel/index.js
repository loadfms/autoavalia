import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Card from '../Card';
import {fetchCluster} from './../../actions/index';

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
		});
	}

	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--total-progress">
						<Card title={"Avaliação do veículo"} type={"internal"} cluster={"total-progress"} />
					</section>
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
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