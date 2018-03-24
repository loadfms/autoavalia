import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import { fetchReport } from './../../actions/index';
import { withRouter } from 'react-router-dom';
import Card from './../Card';


export default class Report extends Component {
	constructor(props) {
		super(props);

		this.handleMyselfClick = this.handleMyselfClick.bind(this);
		this.onClickBackButton = this.onClickBackButton.bind(this);
	}

	componentWillMount() {
		fetchReport(this.props.match.params.questionary, (response) => {
			console.log(response);
		});
	}

	handleMyselfClick() {
		this.props.history.push('/painel');
	}

	onClickBackButton() {
		this.props.history.goBack();
	}

	render() {
		return (
			<div className="page page--report">
				<Header onClick={this.handleMyselfClick} onClickBackButton={this.onClickBackButton} />
				<main className="main">
					<section className="section section--car-data">
						<div className="container">
							<h2 className="section__title">Resultado da avaliação</h2>
						</div>
						<div className="car-data">
							<div className="car-data__image">
								<img src="https://loremflickr.com/320/180" />
							</div>
							<div className="container">
								<div className="car-data__content">
									<h3 className="car-data__title">Audi A3</h3>
									<span className="car-data__price">R$ 2.879.900</span>
									<span className="car-data__description">1.4 TFSI SPORTBACK ATTRACTION 16V GASOLINA</span>
									<span className="car-data__author"><strong>Feita por:</strong> Amarildo Silva • São Paulo </span>
								</div>
							</div>
						</div>
					</section>
					<section className="section section--car-report">
						<div className="container">
							<div className="cards">
								<Card title={"Situação do veículo"} description={"Dados de documentação e uso"} cluster={"situation"}/>
								<Card title={"Histórico do veículo"} description={"Dados de documentação e uso"} cluster={"historic"} />
								<Card title={"Interior"} description={"Dados de documentação e uso"} cluster={"inside"} />
								<Card title={"Funilaria"} description={"Dados de documentação e uso"} cluster={"funnel"} />
								<Card title={"Pneus"} description={"Dados de documentação e uso"} cluster={"tires"} />
								<Card title={"Elétrica"} description={"Dados de documentação e uso"} cluster={"eletric"} />
								<Card title={"Mecânica"} description={"Dados de documentação e uso"} cluster={"mechanic"} />
							</div>
						</div>
					</section>
				</main>
				<Footer />
			</div>
		);
	}
}